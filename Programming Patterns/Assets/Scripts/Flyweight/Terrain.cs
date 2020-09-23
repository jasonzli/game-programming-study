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

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        setCubeInfoPanel = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<SetCubeInfo>();
        BakeTerrainProperties();

    }

    void OnMouseDown(){
        setCubeInfoPanel.OpenCubePanel();
        setCubeInfoPanel.cubeHeight.text = info.Height.ToString();
        setCubeInfoPanel.cubeType.text = info.Type;
        setCubeInfoPanel.isWater.text = info.IsWater ? "Water" : "Not Water";
        setCubeInfoPanel.color.text = info.Color.ToString();
    }

    void BakeTerrainProperties(){
        var MaterialProp = new MaterialPropertyBlock();
        MaterialProp.SetColor("_Color", info.Color);
        _renderer.SetPropertyBlock(MaterialProp);
        
        transform.Translate(Vector3.up * (int) info.Height);
    }


}
