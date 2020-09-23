using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MouseOverFlyweight : MonoBehaviour
{

    public static Action MouseHits;
    
    private Camera camera;
    public GameObject UIElement;

    private int layerMask = 1 << 5;
    void Start()
    {
        camera = Camera.main;
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition),
            out hit, 100f, layerMask);

        if (hit.transform == null){
            UIElement.GetComponent<SetCubeInfo>().CloseCubePanel();
        }else{
            hit.transform?.GetComponent<Terrain>()?.SendCubeData();
        }
    }
}
