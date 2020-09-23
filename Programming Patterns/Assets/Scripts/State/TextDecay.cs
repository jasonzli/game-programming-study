using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDecay : MonoBehaviour
{

    TextMeshProUGUI text;
    public float decaySpeed;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.alpha = Mathf.Max(text.alpha - decaySpeed * Time.deltaTime /100,0);
    }
}
