using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{

    public void GoToCommandScene(){
        GoToScene("Command Scene");
    }

    public void GoToFlyWeightScene(){
        GoToScene("Flyweight Scene");
    }
    private void GoToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
