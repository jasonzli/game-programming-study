using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(StatTracker.Instance.ResetClicks);
    }

    void OnDisable(){
        GetComponent<Button>().onClick = null;
    }
}
