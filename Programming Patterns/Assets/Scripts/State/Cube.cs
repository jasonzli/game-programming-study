using System.Collections;
using UnityEngine;
using System;
using StateMachine;

public class Cube : MonoBehaviour{

    FiniteStateMachine<Cube> FSM;

    private void Start() {
        FSM = new FiniteStateMachine<Cube>(this);
        FSM.ChangeState(new Idle<Cube>(FSM));
    }

    private void Update(){
        FSM.Update();
    }
}

public class Idle<TContext> : State<TContext>{
    
    private FiniteStateMachine<TContext> ParentMachine;
    public Idle (FiniteStateMachine<TContext> _ParentMachine){
        ParentMachine = _ParentMachine;
    }

    public void Enter(){
        Debug.Log($"Machine has entered Idle state");
    }
    public void Update(){
        HandleInput(ParentMachine);
    }

    void HandleInput(FiniteStateMachine<TContext> context){
        if (Input.GetKeyDown("space")){
            //ParentMachine.ChangeState(new Jumping<TContext>());
            ParentMachine.transform.GetComponent<Rigidbody>().AddForce(ParentMachine.transform.up * 250);
        }
    }
}
