using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandPattern;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private float MoveDistance = 1f;
    private Transform boxTransform;
    
    //Stores all commands for undo
    [SerializeField]
    public Stack<Command> previousCommands = new Stack<Command>();

    #region Buttons
    private Command buttonW, buttonA, buttonS, buttonD, buttonR;
    
    #endregion

    void Start(){
        boxTransform = GetComponent<Transform>();
        //Command binding has to happen in the start function
        
        buttonW = new MoveUp();
        buttonS = new MoveDown();
        buttonA = new MoveLeft();
        buttonD = new MoveRight();
        buttonR = new UndoCommand();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    void ReadInput(){
        
        if (Input.GetKeyDown(KeyCode.W)){
            buttonW.Execute(boxTransform,buttonW);
        }
        if (Input.GetKeyDown(KeyCode.A)){
            buttonA.Execute(boxTransform,buttonA);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            buttonS.Execute(boxTransform,buttonS);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            buttonD.Execute(boxTransform,buttonD);
        }
        if (Input.GetKeyDown(KeyCode.R)){
            buttonR.Execute(boxTransform,buttonR);
        }
        
    }
}
