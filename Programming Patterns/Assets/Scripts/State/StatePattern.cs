using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{//FROM https://faramira.com/implementing-a-finite-state-machine-using-c-in-unity-part-1/

    //1. This is the basic structure of the Finite State Machine
    public class State{
        //a state must have access to the parent fsm

        protected FSM m_fsm;

        public State(FSM _machine){
            m_fsm = _machine;
        }

        //5. these enter and exits let us actually do the movement between states
        public virtual void Enter (){}
        public virtual void Exit() {}

        /*And now we give the two main active functions to the class that Unity will call back
          FixedUpdate and Update both are necessary for this work
        */

        public virtual void Update(){

        }

        public virtual void FixedUpdate(){

        }
    }

    public class FSM{
        //2. A container to store the states - an FSM must be initialized with the states it will take
        //*A dictionary is used to store these, a key value of unique IDs for states.
        //This lets us see the key

        protected Dictionary<int, State> m_states;

        protected State m_currentState;
        public FSM()
        {
        }

        public void Add (int key, State state){
            //3.Fails if the key is not in the state machine
            //remember: FINITE
            m_states.Add(key,state);
        }

        public void SetCurrentState(State state){
            if (m_currentState != null)
            {
                //4. if the existing state is valid
                //do something here
                //Because we don't want to overwrite, we want to TRANSITION

                //6.So now we call exit on the previous state
                m_currentState.Exit(); // can be condensed into m_currentState?.Exit();

            }
            //when the current state is null or invalid, we do this immediately
            m_currentState = state;

            //6. And then do the enter on the new state
            if (m_currentState != null){
                m_currentState.Enter();
            }
        }

        public void Update(){
            m_currentState?.Update();
        }

        public void FixedUpdate() {
            m_currentState?.FixedUpdate();
        }
    }
}
