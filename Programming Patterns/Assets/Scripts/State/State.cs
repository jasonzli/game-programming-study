using System.Collections;
using UnityEngine;
using System;


//This is the basic State and state machine,
//Unsure if the IEnumerator version is necessary/
//Seems good to put start stuff in IEnumerator, but part of the state pattern
//is to guarantee that things are in place before continuing.
//If you halt execution of other code, then it's important to ... not Coroutine it?
namespace StateMachine{
    public abstract class State<TContext>{

        //States have FSM contexts
        internal FiniteStateMachine<TContext> Parent {get; set;}

        protected TContext Context {get {return Parent._context;}}

        public virtual void Enter(){
            UnityEngine.Debug.Assert(Context != null, "State has no context!");
        }

        public virtual void Update(){
            UnityEngine.Debug.Assert(Context != null, "State has no context!");
        }

        public virtual void Exit(){
            UnityEngine.Debug.Assert(Context != null, "State has no context!");
        }
    }
}