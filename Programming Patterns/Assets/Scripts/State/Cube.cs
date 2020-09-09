using System.Collections;
using UnityEngine;
using System;
using StateMachine;

public class Cube : MonoBehaviour{

    FiniteStateMachine<Cube> FSM;


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

public class Idle<Cube> : State<Cube> where Cube : MonoBehaviour{
    
    private Cube Parent;
    public Idle (Cube _Parent){
        Parent = _Parent;
    }

    public override void Enter(){
    }
    public override void Update(){
        
        HandleInput(Parent);
    }

    void HandleInput(Cube context){
        
        Debug.Log($"Machine has entered Idle state");
        if (Input.GetKeyDown("space")){
            Parent.GetFSM().ChangeState(new Jumping<Cube>(Parent));
            Parent.transform.GetComponent<Rigidbody>().AddForce(Parent.transform.up * 250);
        }
    }
}
//yeah the stuff after Jump<TContext> seems too redundant.
public class Jumping<Cube> : State<Cube> where Cube : MonoBehaviour{
    
    private Cube Parent;
    
    public Jumping (Cube _Parent){
        Parent = _Parent;
    }

    public override void Enter(){
    }
    public override void Update(){
        Parent.transform.position = Parent.transform.up * Parent.UpwardSpeed;
        //HandleInput(Parent);
    }

    void HandleInput(Cube context){
        
        Debug.Log($"Machine has entered Idle state");
        if (Input.GetKeyDown("space")){
            //Parent.ChangeState(new Jumping<TContext>());
            //Parent.transform.GetComponent<Rigidbody>().AddForce(Parent.transform.up * 250);
        }
    }
}