using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//In this Observer scene, we simply need an object with some basic properties
//some pooling code taken from https://catlikecoding.com/unity/tutorials/object-management/reusing-objects/
//Thank you Jasper!

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject fallingObjectPrefab;

    [SerializeField]
    Vector2 fallingArea;
    [SerializeField]
    public float creationSpeed;

    [SerializeField]
    private Slider sliderUI;

    List<GameObject> fallingObjects;
    float creationProgress = 0f;

    void OnEnable(){
        fallingObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        creationProgress += Time.deltaTime * creationSpeed * sliderUI.value;
        if (creationProgress >= 1f){
            creationProgress = 0f;
            var o = CreateFallingObject();
            o.transform.position = new Vector3(
                UnityEngine.Random.Range(-fallingArea.x,fallingArea.x),
                6.8f, 
                UnityEngine.Random.Range(-fallingArea.y,fallingArea.y)
            );
        }
    }

    GameObject CreateFallingObject(){
        GameObject go = Instantiate(fallingObjectPrefab);
        go.GetComponent<Rigidbody>().drag = UnityEngine.Random.Range(0f,5f);
        return go;
    }
}
