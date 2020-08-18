using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatTracker : MonoBehaviour
{
    // Start is called before the first frame update

    public static StatTracker _Instance;
    public static StatTracker Instance { get {return _Instance;} }
    public int _clickCount = 0;
    public int ClickCount {get {return _clickCount;} private set => _clickCount = value;}
    public int _clickCountOutside = 0;
    public int ClickCountOutside {get {return _clickCountOutside;} private set => _clickCountOutside = value;}

    public float _totalTime = 0;
    public float TotalTime {get {return _totalTime;} private set => _totalTime = value;}

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
            if (SceneManager.GetActiveScene().name  == "Singleton Scene"){
                ClickCount++;
            }else{
                ClickCountOutside++;
            }
        }
        TotalTime = Time.realtimeSinceStartup;
    }

    public void ResetClicks(){
        ClickCount = 0;
        ClickCountOutside = 0;
    }

}
