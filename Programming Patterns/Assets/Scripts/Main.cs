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


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var position = Utility.GetMouseInWorldCoordinates();
            position.z = 0f;

            var newObject = ObjectFactory.CreateObject(_ShapePrimitive.value,_MovementComponent.value,_BonusComponent.value);
            newObject.transform.position = position;
        }
    }

}


//Factory pattern!
public static class ObjectFactory
{

    private static PrimitiveType[] _Shapes = {PrimitiveType.Sphere,PrimitiveType.Capsule,PrimitiveType.Cube};
    //using Type requires System
    private static Type[] _MovementTypes = {typeof(ChaseMouse),typeof(AvoidMouse),typeof(RandomWalk),typeof(WalkRight)};
    private static Type[] _ExtraTypes = {null, typeof(ColorPulse),typeof(Pulsate)};

    public static GameObject CreateObject(int shape = 0, int movement = 0, int extra = 0){

        GameObject newObject = createPrimitive(_Shapes[shape]);
        newObject = applyComponents(newObject,
                                _MovementTypes[movement],
                                _ExtraTypes[extra]);
        newObject.AddComponent<Lifetime>();

        return newObject;
    }
    private static GameObject createPrimitive(PrimitiveType shape){                
        return GameObject.CreatePrimitive(shape);
    }
    
    private static GameObject applyComponents(GameObject o,  params Type[] components){
        foreach (Type component in components){
            if (component != null){
                o.AddComponent(component);
            }
        }
        return o;
    }
}