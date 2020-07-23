using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Factory pattern!
public static class ObjectFactory
{

    private static PrimitiveType[] _Shapes = {PrimitiveType.Sphere,PrimitiveType.Capsule,PrimitiveType.Cube};
    //using Type requires System
    private static Type[] _MovementTypes = {typeof(ChaseMouse),typeof(AvoidMouse),typeof(RandomWalk),typeof(WalkRight)};
    private static Type[] _ExtraTypes = {null, typeof(ColorPulse),typeof(Pulsate)};

    //This CreateObject is specifically linked up to the Component pattern implementation
    //It's meant to work with that interface alone -- although we could do other things too.
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