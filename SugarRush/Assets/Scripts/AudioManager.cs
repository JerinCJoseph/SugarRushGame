using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string bgPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider bgSlider;  
    private float backgroundFloat; 
    public AudioSource bgAudio; 

    private void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            backgroundFloat = .25f; //default sound
            bgSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(bgPref, backgroundFloat); //set to playerpref
            PlayerPrefs.SetInt(FirstPlay, -1); 
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(bgPref); //get the saved music vol
            bgSlider.value = backgroundFloat;
        }
    }
    public void SaveSoundSettings()
    { 
         PlayerPrefs.SetFloat(bgPref, bgSlider.value);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if(!infocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound() 
    {
        bgAudio.volume = bgSlider.value;
        Debug.Log("updated volume is " + bgAudio.volume);
    }
}
