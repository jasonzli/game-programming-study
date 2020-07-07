using UnityEngine;

[RequireComponent(typeof(Target), typeof(MoveToTarget))]
public class AvoidMouse : MonoBehaviour
{
    private const float FleeTargetRange = 100;  
    public float avoidDistance = 2f; // the minimum distance from the mouse before avoidance kicks in
    
    private void Update()
    {
        var mousePos = Utility.GetMouseInWorldCoordinates();

        //This is the B->A
        var offsetFromMouse = transform.position - mousePos;
        // we only care about the offset on the x/y plane
        // so we're going to clear the z component
        offsetFromMouse.z = 0;

        var target = GetComponent<Target>();
        
        if (offsetFromMouse.magnitude <= avoidDistance)
        {
            target.position = transform.position + offsetFromMouse.normalized * FleeTargetRange;
        }
        else
        {
            target.position = transform.position;
        }
       
    }
}