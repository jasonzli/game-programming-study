using System.Collections;
using UnityEngine;
using System;
using StateMachine;

public class Cube : MonoBehaviour{

    FiniteStateMachine<Cube> _FSM;
    public FiniteStateMachine<Cube> FSM {get; private set;}

    [SerializeField] float maxJumpHeight = 10f;
    public float MaxJumpHeight {get; private set;}
    [SerializeField] float upwardSpeed = 10f;
    public float UpwardSpeed {get; private set;}

    private void Start() {
        FSM = new FiniteStateMachine<Cube>(this);
        FSM.ChangePendingState(new Idle<Cube>(this));
    }
    
    public FiniteStateMachine<Cube> GetFSM(){
        return FSM;
    }

    private void Update(){
        FSM.Update();
    }

}

public class Idle<TContext> : State<TContext> where TContext : Cube{
    
    private TContext Parent;
    public Idle (TContext _Parent){
        Parent = _Parent;
    }

    public override void Enter(){
    }
    public override void Update(){
        
        HandleInput(Parent);
    }

    void HandleInput(TContext context){
        
        if (Input.GetKeyDown("space")){
        Debug.Log("hello space bar");
            Parent.FSM.ChangePendingState(new Jumping<Cube>(context));
        }
    }
}

public class Airborne<TContext> : State<TContext> where TContext : Cube{

}
//yeah the stuff after Jump<TContext> seems too redundant.
public class Jumping<TContext> : Airborne<TContext> where TContext : Cube{
    
    private TContext Parent;
    
    public Jumping (TContext _Parent){
        Parent = _Parent;
    }

    public override void Enter(){
    }
    public override void Update(){
        Parent.transform.position += Parent.transform.up * Parent.UpwardSpeed * Time.deltaTime;
        
        HandleInput(Parent);
        
        if (Parent.transform.position.y >= Parent.MaxJumpHeight){
            //Parent.FSM.ChangePendingState(new Falling<Cube>(Parent));
        }
    }

    void HandleInput(TContext context){
        if (Input.GetKeyDown("space")){
            
            Parent.FSM.ChangePendingState(new SpinJump<Cube>(Parent));
        }
    }
}

public class Falling<TContext> : Airborne<TContext> where TContext : Cube{
    
    private TContext Parent;
    
    public Falling (TContext _Parent){
        Parent = _Parent;
    }

    public override void Enter(){
    }
    public override void Update(){
        Parent.transform.position += Parent.transform.up * -Parent.UpwardSpeed * Time.deltaTime;
    }

    void HandleInput(TContext context){
        if (Input.GetKeyDown("space")){
            Parent.FSM.ChangePendingState(new SpinJump<Cube>(Parent));
        }
    }
}

public class SpinJump<TContext> : Airborne<TContext> where TContext : Cube{
    
    private TContext Parent;
    float startingHeight;
    public SpinJump (TContext _Parent){
        Parent = _Parent;
        startingHeight = Parent.transform.position.y;
    }

    public override void Enter(){
    }
    public override void Update(){
        Parent.transform.position += Parent.transform.up * Parent.UpwardSpeed *2* Time.deltaTime;
        Parent.transform.Rotate(new Vector3( 0, 20f, 0));

        if (Parent.transform.position.y >= startingHeight + 5f){
            Parent.FSM.ChangePendingState(new Falling<Cube>(Parent));
        }
    }

    
}