using System.Collections;
using UnityEngine;
using System;
using StateMachine;

public class Cube : MonoBehaviour{

    FiniteStateMachine<Cube> FSM;

    private void Start() {
        FSM = new FiniteStateMachine<Cube>(this);
        FSM.ChangePendingState(new Idle<Cube>(this));
    }

    private void Update(){
        FSM.Update();
    }
}

public class Idle<TContext> : State<TContext> where TContext : MonoBehaviour{
    
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
        
        Debug.Log($"Machine has entered Idle state");
        if (Input.GetKeyDown("space")){
            //Parent.ChangeState(new Jumping<TContext>());
            Parent.transform.GetComponent<Rigidbody>().AddForce(Parent.transform.up * 250);
        }
    }
}
