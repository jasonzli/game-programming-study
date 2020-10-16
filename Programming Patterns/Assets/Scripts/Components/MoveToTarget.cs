using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Speed),typeof(Target))]
public class MoveToTarget : MonoBehaviour
{
    //This component is essentially a brain
    //It gives a single set of execution to go to the target location (also a component)
    //Interestingly the idea of a target, "to have a target" is itself a component
    void Update()
    {
        //Cross component communication using the shared parent
        var speed = GetComponent<Speed>();
        Debug.Assert(speed != null);

        var target = GetComponent<Target>();
        Debug.Assert(target != null);

        var pos = transform.position;
        var offsetToTarget = Utility.GetXYOffset (pos, target.position);

        Vector3 offset = offsetToTarget.normalized * Time.deltaTime * speed.value;
        
        // We don't want to overshoot so we clamp the distance traveled to be 
        // no more than the distance to the target
        var distanceToTarget = offsetToTarget.magnitude;
        offset = Vector3.ClampMagnitude(offset, distanceToTarget);

        Vector3 dir = (target.position - transform.position);
        Vector3 displacement = dir * Time.deltaTime * speed.value;

        Debug.Log(Vector3.Distance(target.position,transform.position));

        transform.position += displacement;
    }
}
