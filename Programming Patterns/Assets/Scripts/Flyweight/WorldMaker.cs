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
                Matrix4x4 local = transform.localToWorldMatrix;
                Vector3 cubePos = local.MultiplyPoint(new Vector3(i,j,0));
                var newTerrain = Instantiate(cubePrefab,cubePos,Quaternion.identity,transform);
                newTerrain.GetComponent<Terrain>().Info = cubeData[(int)(Mathf.Floor(Mathf.PerlinNoise((i*.3f + Time.time),(j*.3f + Time.time))*3f))];
                //newTerrain.GetComponent<Terrain>().BakeTerrainProperties();
                world.Add(newTerrain);
            }
        }
        return world;
    }

    public void Bake(){
        foreach(Transform c in cubes){
            c.GetComponent<Terrain>()?.BakeTerrainProperties();
        }
    }

    List<Transform> DeleteWorld(ref List<Transform> world){
        foreach (Transform piece in world){
            Destroy(piece.gameObject);
        }
        
        world.Clear();
        return world;
    }

}
