//The general format for this code is taken and inspired from
//https://gpp.ghirigoro.net/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 GetMouseInWorldCoordinates()
    {
        var mainCamera = Camera.main;
        var position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return position;
    }

    //We do not give random components. We are selecting them
    public static T GetRandomElement<T>(T[] array)
    {
        Debug.Assert(array.Length > 0);
        var i = UnityEngine.Random.Range(0, array.Length);
        return array[i];
    }

    public static Vector2 GetXYOffset(Vector3 from, Vector3 to)
    {
        //align the z coords
        from.z = 0;
        to.z = 0;
        return to-from;
    }
}
