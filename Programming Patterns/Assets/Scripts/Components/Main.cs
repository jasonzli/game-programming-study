//The general format for this code is taken and inspired from
//https://gpp.ghirigoro.net/
//Mattia Romeo's implementation was a fantastic starting point for messing with components

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Main : MonoBehaviour
{

    public TMP_Dropdown _ShapePrimitive;
    public TMP_Dropdown _MovementComponent;
    public TMP_Dropdown _BonusComponent;  

    public List<GameObject> objects;


    public void ChangeComponents(){
        List<GameObject> newObjects = new List<GameObject>(objects.Count);
        foreach (GameObject o in objects){
            var pos = o.transform.position;
            var s = ObjectFactory._Shapes[_ShapePrimitive.value];;
            var newObject = GameObject.CreatePrimitive(s);
            var mType = ObjectFactory._LimitedMovementTypes[_MovementComponent.value];
            if (mType != null) newObject.AddComponent(mType);
            var dType = ObjectFactory._ExtraTypes[_BonusComponent.value];
            if (dType != null) newObject.AddComponent(dType);
            
            newObject.transform.position = pos;
            newObjects.Add(newObject);
            GameObject.Destroy(o);
        }
        objects = newObjects;
        
    }
    // Update is called once per frame
    void Update()
    {
   
    }

}

