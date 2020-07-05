using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetCubeInfo : MonoBehaviour
{
    public GameObject cubeInfoPanel;
    public TextMeshProUGUI cubeHeight;
    public TextMeshProUGUI cubeType;
    public TextMeshProUGUI isWater;
    public TextMeshProUGUI color;


    public void OpenCubePanel()
    {
        cubeInfoPanel.SetActive(true);
    }

    public void CloseCubePanel()
    {
        cubeInfoPanel.SetActive(false);
    }
}
