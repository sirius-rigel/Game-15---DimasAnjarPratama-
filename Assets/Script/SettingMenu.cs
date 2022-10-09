using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown myDrop;
    public TMPro.TMP_Dropdown mySecDrop;
    public Slider slider;
    public Slider secSlider;

    public void LanguageSelector()
    {
        if (mySecDrop.value == 0) Debug.Log("Language has changed to ENGLISH");
        else if (mySecDrop.value == 1) Debug.Log("Language has changed to BAHASA INDONESIA");
        else if (mySecDrop.value == 2) Debug.Log("Language has changed to ITALIANO");
        else if (mySecDrop.value == 3) Debug.Log("Language has changed to DEUTSCH");
        else if (mySecDrop.value == 4) Debug.Log("Language has changed to ESPAÑOL");
    }

    public void DisplaySelector()
    {
        if (myDrop.value == 0) Debug.Log("Screen Display changed to FULLSCREEN");
        else Debug.Log("Screen Display Changed to WINDOWED");
    }

    public void MusicVolume()
    {
        Debug.Log("Music Volume");
        Debug.Log(slider.value);
    }

    public void SFXVolume()
    {
        Debug.Log("SFX Volume");
        Debug.Log(secSlider.value);
    }

    public void userToggle(bool tog)
    {
        if (tog == true)
        {
            Debug.Log("Music is MUTED");
        }
        else
        {
            Debug.Log("Music is ON");
        }
    }

    public void userToggleSFX(bool togSfx)
    {
        if (togSfx == true)
        {
            Debug.Log("SFX is MUTED");
        }
        else
        {
            Debug.Log("SFX is ON");
        }
    }

    public void Term()
    {
        Debug.Log("Open TERM OF USE");
    }

    public void Privacy()
    {
        Debug.Log("Open PRIVACY POLICY");
    }
}
