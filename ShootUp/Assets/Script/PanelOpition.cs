using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpition : PanelAbs {
    string currentResolution;
    string targetResolution;
    
    public override void ShowPanel(CallBackShowPanel callback = null)
    {
        Show = true;
        gameObject.SetActive(true);
    }
    public override void HidePanel(CallBackHidePanel callback = null)
    {        
        Show = false;
        gameObject.SetActive(false);
    }
    
    public void ChangeVolume()
    {
        float volumevalue=transform.Find("MusicVolumeSlider").GetComponent<Slider>().value;
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>().volume = volumevalue;
        AudioControl.Instance.Volume = volumevalue;
        PlayerPrefs.SetFloat("Volume", volumevalue);
    }
    public void ChangeResolution()
    {
        currentResolution = transform.Find("ResolutionDropdown").Find("Label").GetComponent<Text>().text;
        PlayerPrefs.SetString("Resolution", currentResolution);
        int[] resolution = ToInt(currentResolution);
        Screen.SetResolution(resolution[0], resolution[1], false);
    }
}
