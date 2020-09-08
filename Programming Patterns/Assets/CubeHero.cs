using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnumState{
    STATE_IDLE,
    STATE_JUMPING
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

    void HandleInput(){
        switch(CubeState)
        {
            case (EnumState.STATE_IDLE):
                if (Input.GetKeyDown("space")){
                    GetComponent<Rigidbody>().AddForce(transform.up * 300);
                    CubeState = EnumState.STATE_JUMPING;
                }
                break;
            case (EnumState.STATE_JUMPING):

                break;
        }
    }

    void OnCollisionEnter(Collision contact){
        if (contact.gameObject.CompareTag("Floor"))
            CubeState = EnumState.STATE_IDLE;
    }
}
