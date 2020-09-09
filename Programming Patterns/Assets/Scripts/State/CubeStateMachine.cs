using System.Collections;
using UnityEngine;
using StateMachine;

public class Cube : MonoBehaviour{

    public FiniteStateMachine<Cube> FSM {get; set;}

    void Start(){
        FSM = new FiniteStateMachine<Cube>(this);
    }
    
}

public class Idle<Cube> : State<Cube> {//declare that idle is a state of a cube
  
    public Idle(){

    }

    public override void Enter(){

    }

    public override void Update()
    {
        HandleInput();
    }

    private void HandleInput(){
        if (Input.GetKeyDown("space")){
            Context.GetComponent<Rigidbody>().AddForce(transform.up * 250);
            CubeState = EnumState.STATE_JUMPING;
        }
    }
}

public class InAir<Cube> : State<Cube> {//declare that idle is a state of a cube
  
    public Idle(){
        
    }

    public override void Enter(){

    }
}