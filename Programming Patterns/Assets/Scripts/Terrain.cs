using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain
{   
    public Terrain(CubeData data){
        //make sure that using enums actually uses the field, not the enum declaration
        Height =  (int) data.cubeHeight;
        IsWater = data.IsWater;
        TerrainBlock = setMaterialPropertyBlockColor(new MaterialPropertyBlock(), data.color);
        
    }

    public int Height{get ; private set;}
    public bool IsWater{get ; private set;}
    public MaterialPropertyBlock TerrainBlock {get; private set;}

    MaterialPropertyBlock setMaterialPropertyBlockColor(MaterialPropertyBlock block, Color color){
        block.SetColor("_Color", color);
        block.SetColor("_Albedo", color);
        return block;
    }
}
