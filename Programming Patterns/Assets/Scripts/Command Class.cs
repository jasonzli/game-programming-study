using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern{
    
//This generic pattern for me is an execution command that can be called after a reference to a Transform is passed
//It performs the execution *to* the actor, rather than the actor performing the action itself.
public abstract class Command
{
    public abstract void Execute(Transform actorTransform, Command command);
    //A command class should not carry a reference to the actor beyond its immediate execution
    //A local reference prevents the command from being a sharable command between objects
    //It ceases to be a command that is carried out on any actor, but an actor's command
    //That would undo the benefit of the pattern
    
    public virtual void Undo(Transform actorTransform){}
}

public abstract class MoveCommand : Command
{
    //private is class specific
    //protected lets us propagate this variable down the line.
    protected float moveDistance = 1f;
    protected abstract void Move(Transform actorTransform);

}

public class MoveTowardsTarget : MoveCommand
{
    protected Transform target { get; }
    //you can do custom constructors in implementations
    public MoveTowardsTarget(Transform movementTarget){
        target = movementTarget;
    }

    public override void Execute (Transform actorTransform, Command command){

    }

    protected override void Move (Transform actorTransform){

    }

}

public class MoveUp : MoveCommand
{
    public override void Execute(Transform actorTransform, Command command){
        Move(actorTransform);
        actorTransform.gameObject.GetComponent<InputHandler>().previousCommands.Push(command);
    }
    protected override void Move(Transform actorTransform){
        actorTransform.Translate(actorTransform.up*moveDistance);
    }
    public override void Undo(Transform actorTransform){
        actorTransform.Translate(-actorTransform.up*moveDistance);
    }
}

public class MoveDown : MoveCommand
{
    public override void Execute(Transform actorTransform, Command command){
        Move(actorTransform);
        actorTransform.gameObject.GetComponent<InputHandler>().previousCommands.Push(command);
    }
    protected override void Move(Transform actorTransform){
        actorTransform.Translate(-actorTransform.up*moveDistance);
    }
    public override void Undo(Transform actorTransform){
        actorTransform.Translate(actorTransform.up*moveDistance);
    }
}

public class MoveRight : MoveCommand
{
    public override void Execute(Transform actorTransform, Command command){
        Move(actorTransform);
        actorTransform.gameObject.GetComponent<InputHandler>().previousCommands.Push(command);
    }
    protected override void Move(Transform actorTransform){
        actorTransform.Translate(actorTransform.right*moveDistance);
    }
    public override void Undo(Transform actorTransform){
        actorTransform.Translate(-actorTransform.right*moveDistance);
    }
}

public class MoveLeft : MoveCommand
{
    public override void Execute(Transform actorTransform, Command command){
        Move(actorTransform);
        actorTransform.gameObject.GetComponent<InputHandler>().previousCommands.Push(command);
    }
    protected override void Move(Transform actorTransform){
        actorTransform.Translate(-actorTransform.right*moveDistance);
    }
    public override void Undo(Transform actorTransform){
        actorTransform.Translate(actorTransform.right*moveDistance);
    }
}

//Undo is a non movement based command that runs the Undo command of a list of commands
//from within an actor
public class UndoCommand : Command
{
    public override void Execute(Transform actorTransform, Command command){
        
        Stack<Command> actorCommandStack = actorTransform.gameObject.GetComponent<InputHandler>().previousCommands;
        if (actorCommandStack.Count < 1) return;

        Command lastCommand = actorCommandStack.Pop();
        lastCommand?.Undo(actorTransform);

    }
    
}


}