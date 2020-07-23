using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionObserver : MonoBehaviour
{
    //A Better way would put this in an Event manager with custom events
    public Action<Vector3> PlaneIntersected;

    private void OnTriggerEnter(Collider other) {

        PlaneIntersected?.Invoke(other.transform.position);

    }
}
