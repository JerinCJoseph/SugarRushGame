using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string bgPref = "BackgroundPref";
    // private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float bgFloat; // soundEffectsFloat;
    public AudioSource bgAudio;
    //public AudioSource[] sfxAudio;

    void Awake()
    {
        ContinueSettings(); 
    }

    // Update is called once per frame
    private void ContinueSettings()
    {
        bgFloat = PlayerPrefs.GetFloat(bgPref);
        bgAudio.volume = bgFloat;
    }
}
