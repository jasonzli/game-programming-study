using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldMaker : MonoBehaviour
{
    List<Transform> cubes = new List<Transform>();
    [SerializeField]
    private Transform cubePrefab;

    [SerializeField]
    private List<CubeData> cubeData = new List<CubeData>();

    [SerializeField]
    private int worldSize;
    // Start is called before the first frame update
    void Awake()
    {
        

    }

    void Start()
    {
        cubes = MakeWorld(cubePrefab, worldSize);
    }

    //you should have seperated this
    List<Transform> MakeWorld(Transform worldPrefab, int size)
    {
        var world = new List<Transform>();
        for (int i = 0; i < size; i++){
            for (int j = 0 ; j < size; j ++){
                var newTerrain = Instantiate(cubePrefab,new Vector3((float) i , (float) j, 0f),Quaternion.identity,transform);
                world.Add(newTerrain);
            }
        }
        return world;
    }
}
