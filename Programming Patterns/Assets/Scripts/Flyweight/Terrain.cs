using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{   
    [SerializeField]
    public CubeData info;

    private Renderer _renderer;

    [SerializeField]
    SetCubeInfo setCubeInfoPanel;
    //autoproperties
    //are: public <type> #Name# {get; set;}
    public CubeData Info { set {this.info = value;}}
    public Camera cam;
    void Start()
    {
        cam = Camera.main;
        _renderer = GetComponent<Renderer>();
        setCubeInfoPanel = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<SetCubeInfo>();

    }

    public void Update(){

    }

    public void SendCubeData(){
        setCubeInfoPanel?.OpenCubePanel();
        if (setCubeInfoPanel == null) return;
        
        setCubeInfoPanel.cubeHeight.text = $"Height: {info.Height.ToString()}";
        setCubeInfoPanel.cubeType.text = $"Cube Type: {info.Type}";
        setCubeInfoPanel.isWater.text = info.IsWater ? "Water" : "Not Water";
        setCubeInfoPanel.color.text = $"Shared Color: {info.Color.ToString()}";
    }

    public void BakeTerrainProperties(){
        var MaterialProp = new MaterialPropertyBlock();
        MaterialProp.SetColor("_Color", info.Color);
        _renderer.SetPropertyBlock(MaterialProp);
        
        transform.position = new Vector3(transform.position.x, 5f + (float) info.Height, transform.position.z);
    }


}
