using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Target), typeof(MoveToTarget))]
public class ChaseMouse : MonoBehaviour
{
    Target target;

    void OnEnable(){
        target = GetComponent<Target>();
    }
    void Update()
    {
        target.position = Utility.GetMouseInWorldCoordinates();
        target.position.z = transform.position.z;
    }
}
