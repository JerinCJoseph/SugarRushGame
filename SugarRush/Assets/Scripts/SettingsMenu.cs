using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown graphicsDropdown; 
    Resolution[] resolutionsList;

    // Start is called before the first frame update
    void Start()
    {
        resolutionsList = Screen.resolutions; //get all resolutions
        resolutionDropdown.ClearOptions();
        List<string> resOptions = new List<string>();

        int currentResIndex = 0;
        //fill resolution dropdown
        for (int i = 0; i < resolutionsList.Length; i++)
        {
            string option = resolutionsList[i].width + "x" + resolutionsList[i].height;
            resOptions.Add(option);

            if (resolutionsList[i].width == Screen.currentResolution.width &&
                resolutionsList[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resOptions);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();

        graphicsDropdown.ClearOptions();
        List<string> graphicsOptions = new List<string>();
        //fill graphics dropdown
        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            graphicsOptions.Add(QualitySettings.names[i]);
        }
        graphicsDropdown.AddOptions(graphicsOptions);
        graphicsDropdown.value = QualitySettings.GetQualityLevel(); // Set current quality level
        graphicsDropdown.RefreshShownValue();

    }
    public void HandleResolutionInput(int resVal)  
    {
        Resolution resolution = resolutionsList[resVal];
        Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
    }

    public void HandleGraphicsInput(int graphicsVal) 
    {
        QualitySettings.SetQualityLevel(graphicsVal);
    }
}
