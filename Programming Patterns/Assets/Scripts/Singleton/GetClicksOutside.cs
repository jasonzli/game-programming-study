using TMPro;
using UnityEngine;

public class GetClicksOutside : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = 
        $"Other Scene Clicks: {StatTracker.Instance.ClickCountOutside}";
    }
}
