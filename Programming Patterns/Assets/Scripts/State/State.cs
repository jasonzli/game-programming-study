using System.Collections;


//This is the basic State and state machine,
namespace StateMachine{
    public abstract class State{

        protected FiniteStateMachine Context;
        
        public State( FiniteStateMachine context ){
            Context = context; // set to context
        }

        public virtual IEnumerator Start(){
            yield break;
        }

        public virtual IEnumerator Update(){
            yield break;
        }

        public virtual IEnumerator Exit(){
            yield break;
        }
    }
}