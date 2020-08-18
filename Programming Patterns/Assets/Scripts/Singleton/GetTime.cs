using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<TextMeshProUGUI>().text = 
        $"Time: {Mathf.Round(StatTracker.Instance.TotalTime)} seconds";
    }
}
