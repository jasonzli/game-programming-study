using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionObserver : MonoBehaviour
{
    public Action<Vector3> PlaneIntersected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        PlaneIntersected?.Invoke(other.transform.position);

    }
}
