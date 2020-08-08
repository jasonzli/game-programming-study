using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeFactory : MonoBehaviour
{
    [SerializeField]
    private Prototype _prototypeObject;
    
    [SerializeField]
    private bool AddPhysics = false;

    [SerializeField]
    [Range(1,10)]
    private int numberOfClones;

    //Object Pooling method
    //Queue<GameObject> availableObjects = new Queue<GameObject>();

    void OnEnable(){
    }

    public void ClonePrototype(){
        for (int i = 0; i < numberOfClones; i++){
            GameObject go = _prototypeObject.clone(transform.position);
            if (AddPhysics){
                go.AddComponent<Rigidbody>();
            }
            go.AddComponent<Lifetime>();
            go.GetComponent<Lifetime>().timeLeft = 12f + Random.Range(-2f, 2f);
        }
        
    }
}
