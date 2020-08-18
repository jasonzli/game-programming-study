using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpOnClick : MonoBehaviour
{

    public float jumpForce = 300f;
    // Start is called before the first frame update
    public void JumpUp(){
        GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
    }

}
