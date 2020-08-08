using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//In this Observer scene, we simply need an object with some basic properties
//some pooling code taken from https://catlikecoding.com/unity/tutorials/object-management/reusing-objects/
//Thank you Jasper!

//pool implementation jason weimann from https://www.youtube.com/watch?v=7UswSdevSpw

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

    Queue<GameObject> availableObjects = new Queue<GameObject>();
    float creationProgress = 0f;

    public static Spawner Instance {get; private set;}

    void OnEnable(){
        Instance = this;
        GrowPool();
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
    
    void GrowPool(){
        for (int i = 0; i < 10; i++){
            var instanceToAdd = Instantiate(fallingObjectPrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    //this is use to add to the queue
    public void AddToPool(GameObject instance){
        //inactive instances are ready to be used
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
    public GameObject GetFromPool(){
        if (availableObjects.Count == 0)
            GrowPool();

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    GameObject CreateFallingObject(){
        GameObject go = Spawner.Instance.GetFromPool();
        go.GetComponent<Rigidbody>().drag = UnityEngine.Random.Range(0f,5f);
        return go;
    }
}
