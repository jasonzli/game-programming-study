using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{

    [SceneNamePicker]
    public string SceneName;

    [SceneNamePicker(showPath = false)]
    public string OtherSceneName;
    
    public void GoToCommandScene(){
        GoToScene("Command Scene");
    }

    public void GoToFlyWeightScene(){
        GoToScene("Flyweight Scene");
    }

    public void GoToPickScene(){
        GoToScene("Pick Scene");
    }
    private void GoToScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
