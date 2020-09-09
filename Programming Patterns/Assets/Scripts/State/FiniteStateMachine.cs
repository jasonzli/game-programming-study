using System.Collections;
using UnityEngine;
using System;


//the Infallible Code approach that uses Coroutines
//https://www.youtube.com/watch?v=G1bd75R10m4

//Infallible Code's approach sets all of the state behaviors to coroutines
//And that way we can trap the behavior into the coroutine, which will run
//separately, but not in the update loop. Whether or not that is a good idea
//is a matter of debate.
namespace StateMachine{

    public abstract class FiniteStateMachine : MonoBehaviour{

        //States carry reference to the parent context now.
        //This is actually closer to the outline in the Game programming patterns book
        //This way the state itself has a pointer to it (and in this case it is a reference)
        //Dependency is injected but not dynamically
        public State CurrentState {get; private set;}
        private State _pendingState;

        public FiniteStateMachine(State StartingState){
            CurrentState = StartingState;
        }

        public void Start(){
            UnityEngine.Debug.Assert(CurrentState != null, "FSM in null state! Failure to set");
            CurrentState?.Enter();
        }

        public void Update(){
            TransitionToPendingState();
            UnityEngine.Debug.Assert(CurrentState != null, "FSM in null state! Failure to set");

            CurrentState.Update();

            TransitionToPendingState();
        }
        public void SetPendingState(State s){
            _pendingState = s;
        }

        private void TransitionToPendingState(){
            if (_pendingState == null) return;
            if (CurrentState == null) return;

            CurrentState.Exit();

            CurrentState = _pendingState;
            CurrentState.Enter();
            _pendingState = null;

        }
        

        //So this stuff is to let the state machine directly change from anywhere
        //This is not using a state to change it I guess?
        public void TransitionTo<TState>() where TState : State{
            _pendingState = CreateState<TState>();
        }

        //Deviation from GPP ghirigoro: we do not use instance
        //and our states do not have parents, but have contexts instead
        //and can dynamically move around at runtime
        private TState CreateState<TState>() where TState : State{
            var newState = Activator.CreateInstance<TState>();
            newState.SetContext(this);
            return newState;
        }
    }

}
