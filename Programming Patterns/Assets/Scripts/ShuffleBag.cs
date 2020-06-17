using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adapted from https://gamedevelopment.tutsplus.com/tutorials/shuffle-bags-making-random-feel-more-random--gamedev-1249
public class ShuffleBag<T>
{
    //unity random does not support the .Next() functionality that we will use, but C# system *does*
    private System.Random random = new System.Random();
    private List<T> data;

    private T currentItem;
    private int currentPosition = -1;

    private int Capacity {get {return data.Capacity;} }
    private int Size {get {return data.Count;}}
   
    public ShuffleBag (int initCapacity)
    {
        data = new List<T>(initCapacity);
    }
    public ShuffleBag ()
    {
    }


    public void Add(T item, int amount)
    {
        for (int i = 0; i < amount; i++){
            data.Add(item);
        }
        //starting from the end and working back is cleaner
        currentPosition = Size - 1;
    }

    public T Next()
    {
        if (currentPosition < 1){
            currentPosition = Size - 1;
            currentItem = data[0];

            return currentItem;
        }

        //get a random position in the list
        var pos = random.Next(currentPosition);
        //get the value at that position and store it in currentItem
        currentItem = data[pos];
        //**swap** the item in that position with our current position
        data[pos] = data[currentPosition];
        //Change the current position to the selected item
        data[currentPosition] = currentItem;
        //Move forward in the list
        currentPosition--;
        //Return the item
        return currentItem;
    }
}
