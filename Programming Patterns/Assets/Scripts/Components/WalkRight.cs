using UnityEngine;

[RequireComponent(typeof(Speed))]
public class WalkRight : MonoBehaviour
{
    Speed speed;

    void OnEnable(){

        speed = GetComponent<Speed>();
        Debug.Assert(speed != null);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed.value * Time.deltaTime);
    }
}