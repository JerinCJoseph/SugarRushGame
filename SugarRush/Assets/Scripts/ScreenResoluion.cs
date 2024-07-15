using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenResoluion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    public void ScreenRes1() 
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }
    public void ScreenRes2()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
