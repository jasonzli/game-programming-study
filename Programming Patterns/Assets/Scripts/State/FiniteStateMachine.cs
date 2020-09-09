using System.Collections;
using UnityEngine;
using System;
using System.Reflection;


//the Infallible Code approach that uses Coroutines
//https://www.youtube.com/watch?v=G1bd75R10m4

//Infallible Code's approach sets all of the state behaviors to coroutines
//And that way we can trap the behavior into the coroutine, which will run
//separately, but not in the update loop. Whether or not that is a good idea
//is a matter of debate.
namespace StateMachine{

    public class FiniteStateMachine<TContext> where TContext : MonoBehaviour{

        State<TContext> CurrentState;
        State<TContext> PendingState;

        public TContext context;

        public FiniteStateMachine (TContext _context){
            context = _context;
        }

        public void ChangePendingState(State<TContext> _pendingState) {
            if (_pendingState == null) return;
            PendingState = _pendingState;
        }

        public void ChangeState ( State<TContext> newState ){
            
            if (newState == null) return;
            if (CurrentState != null) CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
        
        public void Update() {
            ChangeState(PendingState);
            CurrentState.Update();

            ChangeState(PendingState);
        }


    }

    //dependency injection method
    public abstract class State<TContext> where TContext : MonoBehaviour {
        public virtual void Enter() {}
        public virtual void Update() {}
        public virtual void Exit(){}

    }

}
