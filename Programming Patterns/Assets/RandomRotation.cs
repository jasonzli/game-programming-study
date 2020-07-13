using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public Vector3 rotationDirection;
    public float rotationSpeed = 52f;

    void OnEnable(){
        rotationDirection = new Vector3(
            Random.Range(-1f,1f),
            Random.Range(-1f,1f),
            Random.Range(-1f,1f)
        );

        rotationDirection = rotationDirection.normalized;
    }
    void Update()
    {
        transform.Rotate(Time.deltaTime * rotationSpeed * rotationDirection,Space.Self);
    }
}
