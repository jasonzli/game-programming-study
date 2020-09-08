using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Diagnostics;
using System;

public class CubeClassState : MonoBehaviour
{
    private FSM<CubeClassState> _fsm;

    void Start(){
        _fsm = new FSM<CubeClassState>(this);//TContext is of type in the class

        //_fsm.TransitionTo<Idle>();
    }
}





//Adapted from https://bitbucket.org/gameplayprogrammingpatterns/fsm/src/master/Assets/Scripts/Util/FSM.cs
public class FSM<TContext>
{
    //Because states need to access the parent context, we give it a TContext
    //This allows the state to look at the context that they exist in.
    //a readonly property is used to make sure that no one can change the context

    protected readonly TContext _context;
    public State CurrentState {get; private set;}

    private State _pendingState;// queue state changes rather than immediately change them

    //from Mattia romeo
    public FSM(TContext context){
        _context = context;
    }


    //So the original implementation uses the update to actually return a State
    //instead we will keep that as a pendingState to transition out of it
    public void Update(){
        
        //Do any state transition, this should only occur if someone tells the FSM to change from OUTSIDE
        TransitionToPendingState();

        //do a transition from outside sources?
        UnityEngine.Debug.Assert(CurrentState != null, "FSM has null state, confirm starting state");
        CurrentState.Update();

        //Do any state transition
        TransitionToPendingState();
    }

    //This is the set state function
    private void TransitionToPendingState(){
        if (_pendingState != null){
            if (CurrentState != null) CurrentState.OnExit();
            CurrentState = _pendingState;
            CurrentState.OnEnter();
            _pendingState = null;
        }
    }

    public void SetPendingState(State s){
        _pendingState = s;
    }

    //Set Pending state.. using the dictionary method which is not implemented here
    public void TransitionTo<TState>() where TState : State{
        _pendingState = CreateState<TState>();
    }

    //Returns something of Type State TState
    //we use create state to avoid the dictionary problem.... we maybe shouldn't.
    private TState CreateState<TState>() where TState : State
    {
        // Activator lets us create an object that matches the Type that we send it, in this case
        //we invoke with TState and so we can arbitrarily create any state from any other state.
        //requires "using System;"
        var newState = Activator.CreateInstance<TState>();
        newState.Parent = this;
        newState.Init();
        return newState;
    }

    //State is defined as part of the FSM class
    //This way State is never created outside of it.
    public abstract class State
    {
        //We use internal here because we want it only inside the FSM to be available
        internal FSM<TContext> Parent {get ; set;}
        protected TContext Context {get { return Parent._context;}} //makes getting context easier

        //Set up a pending state transition
        protected void TransitionTo<TState>() where TState : State{
            Parent.TransitionTo<TState>();
        }

        //We use these as public so the parent can actually call them (we would otherwise use Pointers)
        //And this keeps the classes available for implementation
        //this is a restriction introduced by mattia's implementation

        public virtual void Init(){}
        public virtual void OnEnter(){}
        public virtual void OnExit(){}
        public virtual void Update(){}
        public virtual void CleanUp(){}//resource clearing?

        //Init is called when the state is created.
    }
    public class Idle : State{
        public override void Update(){
            UnityEngine.Debug.Log(Context);
        }
    }
}



    /*Another method for setting states
    //I feel like this is faster? Why not just send... _pendingstate into a function for transformation?
    //Basic exit and entry functions
    public void SetState(State state){
        if (currentState != null){
            currentState.Exit();
        }

        currentState = state;

        if (currentState != null){
            currentState.Enter();
        }
    }
    */