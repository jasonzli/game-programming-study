using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    private Camera cam;
    private int layerMask = 1 << 9;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //this is the layer mask explained in the Unity docs. 
        //No I can't explain bitmasking.
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),
                out hit, Mathf.Infinity, layerMask);
            //Look at this cute little double null check
            //Also jumping being part of the public cube api was... a choice
            hit.transform?.GetComponent<JumpOnClick>()?.JumpUp();
        }
    }
}
