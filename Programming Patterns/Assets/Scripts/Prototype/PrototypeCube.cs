using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prototype : MonoBehaviour
{
    public abstract GameObject clone(Vector3 position);
}

public class PrototypeCube : Prototype
{
    private MaterialPropertyBlock _propertyBlock;
    private Renderer _renderer;
    
    void OnEnable(){
        _propertyBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }

    override public GameObject clone(Vector3 position){
        GameObject clone = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _renderer.GetPropertyBlock(_propertyBlock);
        clone.transform.position = position;
        clone.transform.rotation = transform.rotation;
        clone.transform.localScale = transform.localScale;
        clone.GetComponent<Renderer>().SetPropertyBlock(_propertyBlock);

        return clone;
    }
}
