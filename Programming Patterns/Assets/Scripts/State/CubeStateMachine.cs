using System.Collections;
using UnityEngine;
using StateMachine;

public class CubeStateMachine : FiniteStateMachine{

    //CubeStateMachine has a state that it delegates function calls to

    void Start(){
        CurrentState = new Idle(this);
    }
    
}

public class Idle : State {
    public Idle(FiniteStateMachine cubeStateMachine) : base(cubeStateMachine)
    {
        //gives access to a context
    }

    public override void Start(){
        
    }
}