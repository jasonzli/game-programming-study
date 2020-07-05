using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "cubedata", menuName = "Cube Data", order = 51)]
public class CubeData : ScriptableObject
{

    //this is just a data structure of permanent types
    public enum HEIGHT {Low, Medium, High}

    [SerializeField]
    private HEIGHT cubeHeight;

    [SerializeField]
    private string cubeType;
    [SerializeField]
    private bool isWater;
    [SerializeField]
    private Color terrainColor;



    public HEIGHT Height {get {return cubeHeight;}}
    public string Type{get {return cubeType;}}
    public bool IsWater {get {return isWater;}}
    public Color Color {get {return terrainColor;}}


}
