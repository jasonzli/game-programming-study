using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private float MoveDistance = 1f;
    private Transform boxTransform;

    #region Buttons
    
    #endregion

    void Start(){
        boxTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    void ReadInput(){
        
        if (Input.GetKeyDown(KeyCode.W)){
            boxTransform.Translate(boxTransform.up*MoveDistance);
        }
        if (Input.GetKeyDown(KeyCode.A)){
            boxTransform.Translate(-boxTransform.right*MoveDistance);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            boxTransform.Translate(-boxTransform.up*MoveDistance);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            boxTransform.Translate(boxTransform.right*MoveDistance);
        }
        
    }
}
