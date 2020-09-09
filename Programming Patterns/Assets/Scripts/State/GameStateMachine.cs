using System.Collections;
using UnityEngine;
using StateMachine;

public class GameStateMachine : FiniteStateMachine{
    public GameStateMachine (State StartingState){
        base(StartingState);
    }
}