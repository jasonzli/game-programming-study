using UnityEditor;
using UnityEngine;
using System.Linq;

//from http://mfyg.dk/a-cooler-way-to-validate-scene-names-using-custom-attributes/
public class SceneNamePickerPropertyDrawer : PropertyDrawer
{
    private int selectedIndex;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){
        property.serializedObject.Update();

        //find all possible scene names
        SceneNamePicker picker = (SceneNamePicker)attribute;
        string currentSceneName = property.stringValue;

        //check if the string value of the properpty matches a valid scene name
        string[] validSceneNames = GetValidSceneNames(picker.showPath);

        //if it does we find the index of that name in the options
        //in order to keep the value even if the order in the build settings of changes
        if (IsValidSceneName(currentSceneName, picker.showPath)){
            selectedIndex = validSceneNames.ToList().IndexOf(currentSceneName);
        }

        //draw the dropdown and change the string value to reflect the selection
        selectedIndex = EditorGUI.Popup(position, property.displayName, selectedIndex, validSceneNames);
        property.stringValue = validSceneNames[selectedIndex];

        property.serializedObject.ApplyModifiedProperties();
    }

    private string[] GetValidSceneNames(bool includePath){
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        string[] sceneNames = EditorBuildSettingsScene.GetActiveSceneList(scenes);

        for (int i = 0; i < sceneNames.Length; i++){
            if (includePath){
                sceneNames[i] = sceneNames[i].Replace("Assets/","");
                sceneNames[i] = sceneNames[i].Replace(".unity","");
            }
            else{
                sceneNames[i] = AssetDatabase.LoadAssetAtPath<SceneAsset>(sceneNames[i]).name;
            }
        }

        return sceneNames;
    }

    private bool IsValidSceneName(string sceneName, bool includePath)
    {
        string[] sceneNames = GetValidSceneNames(includePath);
 
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (sceneName == sceneNames[i])
            {
                return true;
            }
        }
 
        return false;
    }
}
