using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{


    

    public void GoToPickScene(){
        GoToScene("Pick Scene");
    }
    public void GoToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
