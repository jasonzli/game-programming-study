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
        var displacement = 1f * speed.value * Time.deltaTime;
        if (transform.position.x + displacement > 4f){
            displacement = 0f;
        }
        var right = new Vector3( displacement, 0f, 0f );

        transform.position += right;//(Vector3.right * speed.value * Time.deltaTime);
    }
}