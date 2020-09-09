using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnumState{
    STATE_IDLE,
    STATE_JUMPING,
    STATE_DOUBLE_JUMPING,
    STATE_SLAMMING
}

public class CubeHero : MonoBehaviour
{

    [SerializeField]
    private EnumState CubeState;
    // Start is called before the first frame update
    void Start()
    {
        CubeState = EnumState.STATE_IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

    }

    void FixedUpdate(){
    }

    void HandleInput(){
        switch(CubeState)
        {
            case (EnumState.STATE_IDLE):
                if (Input.GetKeyDown("space")){
                    GetComponent<Rigidbody>().AddForce(transform.up * 250);
                    CubeState = EnumState.STATE_JUMPING;
                }
                break;
            case (EnumState.STATE_JUMPING):
                if (Input.GetKeyDown("space")){
                    GetComponent<Rigidbody>().AddForce(transform.up * 300);
                    GetComponent<Rigidbody>().AddTorque(new Vector3(0f,400f,0f));
                    CubeState = EnumState.STATE_DOUBLE_JUMPING;
                }
                break;
            case (EnumState.STATE_DOUBLE_JUMPING):
                if (Input.GetKeyDown("space")){
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GetComponent<Rigidbody>().AddForce(transform.up * -2000);
                    GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,20000f,0f);
                    CubeState = EnumState.STATE_SLAMMING;
                }
                break;
            case (EnumState.STATE_SLAMMING):
                break;
        }
    }

    void OnCollisionEnter(Collision contact){
        if (contact.gameObject.CompareTag("Floor"))
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            CubeState = EnumState.STATE_IDLE;

            }
    }
}
