using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandPattern;

public class InputHandler : MonoBehaviour
{
    //[SerializeField]
    //private float MoveDistance = 1f;
    private Transform boxTransform;
    
    //Stores all commands for undo
    [SerializeField]
    public Stack<Command> previousCommands = new Stack<Command>();

    #region Buttons
    private Command buttonW, buttonA, buttonS, buttonD, buttonR;
    private List<Command> buttonList = new List<Command>();        
    private List<Command> commandList = new List<Command>() 
        {new MoveUp(), new MoveDown(), new MoveRight(), new MoveLeft()};
    
    private ShuffleBag<Command> commandBag;
    #endregion

    void Start(){
        boxTransform = GetComponent<Transform>();
        commandBag = new ShuffleBag<Command>(commandList.Count);
        foreach(Command c in commandList){
            commandBag.Add(c,1);
        }
        //Command binding has to happen in the start function
        ShuffleInputs(commandBag);
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
            ShuffleInputs(commandBag);
        }

    }

    void ShuffleInputs(ShuffleBag<Command> bag){
        //ideally this should work with the pointers?
        //as is it works with a predefined set
        //maybe this can be a use for enums
        buttonW = bag.Next();
        buttonA = bag.Next();
        buttonS = bag.Next();
        buttonD = bag.Next();
    }
}
