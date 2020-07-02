using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldMaker : MonoBehaviour
{
    List<Terrain> world = new List<Terrain>();
    List<Terrain> types = new List<Terrain>();
    Terrain grassTerrain_;
    Terrain hillTerrain_;
    Terrain riverTerrain_;

    MaterialPropertyBlock riverBlock;
    MaterialPropertyBlock hillBlock;
    MaterialPropertyBlock grassBlock;

    private int worldSize = 100;
    // Start is called before the first frame update
    void Awake()
    {
        riverBlock = new MaterialPropertyBlock();
        hillBlock = new MaterialPropertyBlock();
        grassBlock = new MaterialPropertyBlock();

        riverBlock.SetColor("_Albedo", new Color (0f,119f,190f));
        hillBlock.SetColor("_Albedo", new Color (237f,201f,175f));
        grassBlock.SetColor("_Albedo", new Color (124f,252f,0f));

        grassTerrain_ = new Terrain(1, false, grassBlock);
        hillTerrain_ = new Terrain(2, false, hillBlock);
        riverTerrain_ = new Terrain(0, true, riverBlock);

        types.Add(grassTerrain_);
        types.Add(hillTerrain_);
        types.Add(riverTerrain_);

    }

    void Start()
    {
        MakeWorld();
    }

    void MakeWorld()
    {
        for (int i = 0; i < worldSize; i++){
            Terrain newTerrain = types[Random.Range(0,2)];
            world.Add(newTerrain);

        }
    }
}
