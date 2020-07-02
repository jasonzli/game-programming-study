using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain
{   
    public Terrain(int height, bool isWater, MaterialPropertyBlock materialPropertyBlock){
        Height = height;
        IsWater = isWater;
        TerrainProperty = materialPropertyBlock;
    }

    public int Height{get ; private set;}
    public bool IsWater{get ; private set;}
    public MaterialPropertyBlock TerrainProperty{get ; private set;}

}
