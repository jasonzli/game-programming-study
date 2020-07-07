//The general format for this code is taken and inspired from
//https://gpp.ghirigoro.net/
//Mattia Romeo's implementation was a fantastic starting point for messing with components

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{


    public TMP_Dropdown _ShapePrimitive;
    public TMP_Dropdown _MovementComponent;
    public TMP_Dropdown _BonusComponent;  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var position = Utility.GetMouseInWorldCoordinates();
            position.z = 0f;
            var newObject = ObjectFactory.CreateObject();
            newObject.transform.position = position;
            newObject.AddComponent<Lifetime>();
            newObject.AddComponent<RandomWalk>();
            newObject.AddComponent<ColorPulse>();
        }
    }
}

public static class ObjectFactory
{
    public static GameObject CreateObject(){
        GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        return newObject;
    }
}