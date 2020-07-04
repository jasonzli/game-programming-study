using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "cubedata", menuName = "Cube Data", order = 51)]
public class CubeData : ScriptableObject
{

    //this is just a data structure of permanent types
    public enum HEIGHT {Low, Medium, High}

    [SerializeField]
    public HEIGHT cubeHeight {get; private set;}
    [SerializeField]
    public string cubeType {get; private set;}
    [SerializeField]
    public bool IsWater { get; private set;}
    [SerializeField]
    public Color color {get; private set;}
}
