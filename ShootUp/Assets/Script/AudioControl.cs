using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class AudioControl : MonoBehaviour {    
    static AudioControl instance;
    public static AudioControl Instance
    {
        get
        {
            if (instance == null) instance = new AudioControl();
            return instance;
        }
    }
    public float Volume;
    void Awake()
    {
        this.gameObject.tag = tag;
        GameObject[] audioControls = GameObject.FindGameObjectsWithTag(tag);
        if (audioControls.Length > 1)
        {
            for (int i = 1; i < audioControls.Length; i++)
            {
                Destroy(audioControls[i]);
            }
        }        
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");       
        Volume = GetComponent<AudioSource>().volume;
        DontDestroyOnLoad(this);
    }    
}
