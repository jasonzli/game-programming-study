using System.Collections;
using UnityEngine;
using System;
using StateMachine;

public class Cube : MonoBehaviour{

    FiniteStateMachine<Cube> _FSM;
    public FiniteStateMachine<Cube> FSM {get; private set;}

    [SerializeField] float maxJumpHeight = 10f;
    public float MaxJumpHeight {get {return maxJumpHeight;} private set {maxJumpHeight = value;}}
    [SerializeField] float upwardSpeed = 10f;
    public float UpwardSpeed {get {return upwardSpeed;} private set {upwardSpeed = value;}}

    public bool IsGrounded{get; set;}
    public bool HasSpinJump{get; set;}

    private void Start() {
        IsGrounded = true;
        FSM = new FiniteStateMachine<Cube>(this);
        FSM.ChangePendingState(new Idle<Cube>(this));
    }
    
    public FiniteStateMachine<Cube> GetFSM(){
        return FSM;
    }

    private void Update(){
        FSM.Update();
        if (transform.position.y <= 1){
            FSM.ChangePendingState(new Idle<Cube>(this));
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Floor")){
            FSM.ChangePendingState(new Idle<Cube>(this));
        }

    }

}

public class Idle<TContext> : State<TContext> where TContext : Cube{
    
    private TContext Parent;
    public Idle (TContext _Parent){
        Parent = _Parent;
    }

    public override void Enter(){
        Parent.IsGrounded = true;
        Parent.HasSpinJump = true;
    }
    public override void Update(){
        
        HandleInput();
    }

    void HandleInput(){
        if (Input.GetKeyDown("space")){
            Parent.FSM.ChangePendingState(new Jumping<Cube>(Parent));
        }
    }
}

public abstract class Airborne<TContext> : State<TContext> where TContext : Cube{
    protected bool GroundCheck(Transform p){
        Debug.Log(Physics.Raycast(p.position,Vector3.down,  .001f));
        Debug.DrawRay(p.position,Vector3.down *2f, Color.green);
          
        return Physics.Raycast(p.position,Vector3.down, .001f);
    }
}
//yeah the stuff after Jump<TContext> seems too redundant.
public class Jumping<TContext> : Airborne<TContext> where TContext : Cube{
    
    private TContext Parent;
    
    public Jumping (TContext _Parent){
        Parent = _Parent;
    }

    public override void Enter(){
        Parent.IsGrounded = false;
    }
    public override void Update(){
        //TO DO FIX THIS UPDATE FUNCTION
        Parent.transform.position += Parent.transform.up * Parent.UpwardSpeed * Time.deltaTime;
        
        HandleInput();
        Debug.Log(Parent.MaxJumpHeight);
        if (Parent.transform.position.y > Parent.MaxJumpHeight){
            Parent.FSM.ChangePendingState(new Falling<Cube>(Parent));
        }
    }

    void HandleInput(){
        if (Input.GetKeyDown("space") && Parent.HasSpinJump){
            
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
        HandleInput();
        if (Parent.transform.position.y <= 1){
            Parent.FSM.ChangePendingState(new Idle<Cube>(Parent));
        }
    }

    void HandleInput(){
        if (Input.GetKeyDown("space") && Parent.HasSpinJump){
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
        Parent.HasSpinJump = false;
    }

    public override void Enter(){
    }
    public override void Update(){
        Parent.transform.position += Parent.transform.up * Parent.UpwardSpeed *2f* Time.deltaTime;
        Parent.transform.Rotate(new Vector3( 0, 30f, 0));

        if (Parent.transform.position.y >= startingHeight + Parent.MaxJumpHeight){
            Parent.FSM.ChangePendingState(new Falling<Cube>(Parent));
        }
    }

    
}