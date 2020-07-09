using UnityEngine;

[RequireComponent(typeof(Target), typeof(MoveToTarget))]
public class RandomWalk : MonoBehaviour
{
    public float distance = 2f;

    private void Start()
    {
        SetRandomTarget();
    }

    private void Update()
    {
        // Have we reached the target?
        var target = GetComponent<Target>();
        var distanceToTarget = Utility.GetXYOffset(transform.position, target.position).magnitude;
        var desiredDistance = 0f;
        var hasArrived = Mathf.Approximately(distanceToTarget, desiredDistance); 
        // if so pick a new target
        if (hasArrived)
        {
            SetRandomTarget();
        }
    }

    private void SetRandomTarget()
    {
        var target = GetComponent<Target>();
        Vector3 offset = Random.insideUnitCircle * distance;
        target.position = transform.position + offset;
    }
}