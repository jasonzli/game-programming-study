using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class SceneNamePicker : PropertyAttribute
{
    public bool showPath = true;

    public SceneNamePicker() {}
    public SceneNamePicker(bool showPath){
        this.showPath = showPath;
    }
}
