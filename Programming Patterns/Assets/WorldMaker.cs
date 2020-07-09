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
        FillCubes();
    }


    private void FillCubes(){
        cubes = MakeWorld(cubePrefab, worldSize);
    }

    private void EmptyCubes(){
        cubes = DeleteWorld(ref cubes);
    }

    public void NewWorld(){
        EmptyCubes();
        FillCubes();
    }
    //you should have seperated this
    List<Transform> MakeWorld(Transform worldPrefab, int size)
    {
        var world = new List<Transform>();
        for (int i = 0; i < size; i++){
            for (int j = 0 ; j < size; j ++){
                var newTerrain = Instantiate(cubePrefab,new Vector3((float) i , (float) j, 0f),Quaternion.identity,transform);
                newTerrain.GetComponent<Terrain>().Info = cubeData[Random.Range(0,3)];
                //newTerrain.GetComponent<Terrain>().BakeTerrainProperties();
                world.Add(newTerrain);
            }
        }
        return world;
    }

    List<Transform> DeleteWorld(ref List<Transform> world){
        foreach (Transform piece in world){
            Destroy(piece.gameObject);
        }
        
        world.Clear();
        return world;
    }

}
