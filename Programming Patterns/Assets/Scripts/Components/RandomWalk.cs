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
        var distanceToTarget = (transform.position - target.position).magnitude;//Utility.GetXYOffset(transform.position, target.position).magnitude;
        var hasArrived = distanceToTarget < .001f; //Mathf.Approximately(distanceToTarget, desiredDistance); 

        // if so pick a new target
        if (hasArrived)
        {
            SetRandomTarget();
        }
    }

    private void SetRandomTarget()
    {
        var target = GetComponent<Target>();
        target.position = new Vector3( Random.Range(-4f, 4f), 1f, Random.Range(-4f, 4f) ) ;
        }
}