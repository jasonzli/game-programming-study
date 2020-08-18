using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    // Start is called before the first frame update

    public static StatTracker _Instance;
    public static StatTracker Instance { get {return _Instance;} }
    public int clickCount = 0;
    public float totalTime = 0;

    //here we attach the stat tracker to the world
    void Awake()
    {
        if (_Instance != null && _Instance != this){
            Destroy(this.gameObject);
        }else {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    // private void OnDestroy() {
    //     _Instance = null;
    // }

    public static StatTracker Get(){
        return _Instance;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            clickCount++;
        }
        totalTime = Time.realtimeSinceStartup;
    }
}
