using System.Collections;
using UnityEngine;


//the Infallible Code approach that uses Coroutines
//https://www.youtube.com/watch?v=G1bd75R10m4
namespace StateMachine{

    public abstract class FiniteStateMachine : MonoBehaviour{
        protected State State;

        public void SetState(State state){
            State = state;
            StartCoroutine(State.Start());
        }
    }

}
