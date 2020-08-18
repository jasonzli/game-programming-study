using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Watcher : MonoBehaviour
{

    [SerializeField]
    private Transform eye;

    [SerializeField]
    private Transform _plane;

    [SerializeField]
    float rotationSpeed;

    Quaternion targetRotation;

    void OnEnable(){
        _plane.GetComponent<CollisionObserver>().PlaneIntersected += LookToIntersection;
    }

    void OnDisable(){
        _plane.GetComponent<CollisionObserver>().PlaneIntersected -= LookToIntersection;
    }

    void LookToIntersection(Vector3 target){
        Debug.Log("Intersect");
        Vector3 newLookDirection = target-eye.transform.position;
        Quaternion rot = Quaternion.LookRotation(newLookDirection, Vector3.up);
        targetRotation = rot;
        StopAllCoroutines();
        StartCoroutine(FaceTarget());
    }
    private IEnumerator FaceTarget(){
        while (Quaternion.Angle(eye.transform.rotation, targetRotation) > 0.01f)
        { 
            var step = rotationSpeed * Time.deltaTime;
            eye.transform.rotation = Quaternion.RotateTowards(eye.transform.rotation, targetRotation,step);
            yield return null;
        }
    }

}
