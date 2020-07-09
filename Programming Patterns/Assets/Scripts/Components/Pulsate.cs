using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsate : MonoBehaviour
{
    float timeOffset;
    void OnEnable(){
        timeOffset = Random.Range(0f,100f);
    }
    void Update()
    {
        var _scale = Mathf.Max(.5f * (Mathf.Sin(Time.time * .6f + timeOffset) + 1f),.4f);
        transform.localScale = Vector3.one * _scale;
    }
}
