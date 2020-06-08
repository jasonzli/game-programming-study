using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute();
    public virtual void Undo() { }
}


//Ab
public abstract class MoveCommand : Command
{
    protected float moveDistance = 1f;


}

public class MoveForward : MoveCommand
{
    public override void Execute(){

    }

    public override void Undo(){

    }
}
/*
public class MoveCommand : Command
{
    public override void Execute(Transform targetTransform, Command command)
    {
        Move(targetTransform);
    }

    public override void Undo(Transform targetTransform, Command command)
    {
        UnMove(targetTransform);
    }

    public void Move(Transform targetTransform){

    }
    public  void UnMove(Transform targetTransform){

    }

}*/