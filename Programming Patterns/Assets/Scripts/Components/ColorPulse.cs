using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorPulse : MonoBehaviour
{
    float timeOffset;
    MaterialPropertyBlock _prop;
    Renderer _renderer;

    void OnEnable(){
        timeOffset = Random.Range(0f,100f);
        _prop = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        var H = .5f * (Mathf.Sin(Time.time * .5f + timeOffset)+1f);
        var S = .2f* (Mathf.Sin(Time.time * .8f + timeOffset)) + .7f;
        var V = .8f;
        Color propColor = Color.HSVToRGB(H,S,V);
        _prop.SetColor("_Color", propColor);
        _renderer.SetPropertyBlock(_prop);
    }
}
