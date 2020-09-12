using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;

public class GameBoard : MonoBehaviour
{
    public enum GameStates{
        SETUP = 0,//initialize with zero for some reason?
        PLAY,
        CLEANUP
    }
    private FSM m_fsm = new FSM();

    [SerializeField]
    private GameObject board;
    [SerializeField]
    public Transform Pieces {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        Pieces = transform.Find("Cube Group");
        //FINALLY after declaring the state classes
        //create the three states and add them to the fsm
        m_fsm.Add((int)GameStates.SETUP, new Setup(m_fsm, this));
        m_fsm.Add((int)GameStates.PLAY, new Play(m_fsm,this));
        m_fsm.Add((int)GameStates.CLEANUP, new Setup(m_fsm, this, Setup.MoveType.MOVE_OUT));
        //set the states of the fsm

        m_fsm.SetCurrentState(m_fsm.GetState((int)GameStates.SETUP));
    }

    // Update is called once per frame
    void Update()
    {
        //delegate to the fsm for update function
        m_fsm?.Update();
    }

    private void FixedUpdate() {
        m_fsm?.FixedUpdate();
    }

    public void Exit(){
        Debug.Log("FSM has exited");
        m_fsm = null; //Actually clears the FSM
    }
}

//This setup state is a lot of work to basically jsut get the pieces in place
//But you can abstract this to imagine getting whole game objects set up or established.
//You wouldn't use it for a simple animation like this, but the principle is there
public class Setup : State{
    [SerializeField]
    public float Duration {get; set; } = 2.0f;
    private MoveType moveType;

    public enum MoveType{
        MOVE_IN,
        MOVE_OUT
    }

    private float deltaTime = 0.0f;
    private GameBoard board;
    private Vector3 boardTargetPosition;    
    private Transform pieces;
    private Vector3 boardInitialPosition;

    
    int nextid;
    State nextState;

    //In the declaration of the state we get the actual context that it acts on
    public Setup (FSM fsm, GameBoard _board, MoveType _moveType = MoveType.MOVE_IN) : base(fsm)
    {
        board = _board;
        pieces = board.Pieces;
        moveType = _moveType;
        boardInitialPosition = board.transform.position;
        boardTargetPosition = new Vector3(0,0,0);
    }

    public override void Enter(){
        deltaTime = Time.deltaTime;
        base.Enter();
        switch(moveType)
        {
            case MoveType.MOVE_IN:
                Debug.Log("Entering MoveIn state");
                break;
            case MoveType.MOVE_OUT:
                Debug.Log("Entering MoveOut state");
                break;
        }
    }

    public override void Update() {
        deltaTime += Time.deltaTime;

        //if it's taken more than duration... do this
        //duration is an automatically driven state
        if (deltaTime > Duration){
            switch(moveType){
                case MoveType.MOVE_IN:
                    nextid = (int) GameBoard.GameStates.PLAY;//reference the class then the enum
                    nextState = m_fsm.GetState(nextid);//this is why we have an int key driven state machine
                    m_fsm.SetCurrentState(nextState);
                    break;
                case MoveType.MOVE_OUT:
                    nextid = (int) GameBoard.GameStates.SETUP;//reference the class then the enum
                    nextState = m_fsm.GetState(nextid);//this is why we have an int key driven state machine
                    m_fsm.SetCurrentState(nextState);
                    break;

            }
        }

        if (board != null){
            switch(moveType){
                case MoveType.MOVE_IN:
                    board.transform.position = Vector3.Lerp(boardInitialPosition,boardTargetPosition, deltaTime/Duration);
                    break;
                case MoveType.MOVE_OUT:
                    board.transform.position = Vector3.Lerp(boardTargetPosition,-boardInitialPosition, deltaTime/Duration);
                    break;

            }
        }

    }


}

//////////
//
// Playing state!
//
/////////////
public class Play : State {
    //In the example, this state is designed to play audio
    //in mine, all it does is bring the click behavior into play

    //So it has no duration. Instead it is a state that is exited by a completely different method
    //In this case, it is a button that triggers to exit

    private GameBoard board;

    public Play (FSM fsm, GameBoard board) : base(fsm){
        this.board = board;//we only need the board because we are setting it up
    }

    public override void Enter(){
        board.GetComponent<ClickObject>().enabled = true;
        foreach (Transform hero in board.Pieces){
            hero.gameObject.GetComponent<CubeHero>().enabled = true;
        }
        base.Enter();
        Debug.Log("Entering Play State");
    }

    public override void Update(){
        //we don't do anything here because the board is responsible for turning the input on.
        //we just needed to turn it on, but the board state does not handle that input

        //instead we monitor for when to go off the state
        if (Input.GetKeyDown("j")){
            int nextId = (int) GameBoard.GameStates.CLEANUP;
            State nextState = m_fsm.GetState(nextId);
            m_fsm.SetCurrentState(nextState);
        }
    }

    public override void Exit(){
        board.GetComponent<ClickObject>().enabled = false;
        foreach (Transform hero in board.Pieces){
            hero.gameObject.GetComponent<CubeHero>().enabled = false;
        }
        base.Exit();
    }
}
