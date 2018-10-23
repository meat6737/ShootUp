using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MenuController : MonoBehaviour {
    static MenuController instance;
    public static MenuController Instance
    {
        get
        {
            if (instance == null) instance = new MenuController();
            return instance;
        }
    }
    
    PanelOpition panelOpition;
    PanelCredit panelCredit;
    Text[] Opitions;
    
    void Awake()
    {
        instance = this;
        GetComponent<PanelMenu>().ShowPanel();        
        panelOpition = GameObject.Find("OpitionPanel").GetComponent<PanelOpition>();
        panelCredit = GameObject.Find("CreditPanel").GetComponent<PanelCredit>();
        GameObject.Find("MusicVolumeSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");        
        GameObject.Find("ResolutionDropdown").GetComponent<Dropdown>().value = ResolutionValue(PlayerPrefs.GetString("Resolution"));
        panelOpition.GetComponent<PanelOpition>().ChangeResolution();
        panelOpition.HidePanel();       
        panelCredit.HidePanel();
        //GameObject.Find("LoadConfig").GetComponent<Text>().text = Application.dataPath + "/StreamingAssets/Credit.json";        
    }
    // Use this for initialization
    void Start () {
        GameObject.Find("ScoreBoard").GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("AudioControl").GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
    }
    public void ExitGame()
    {       
        Application.Quit();
    }
    public void Opition()
    {        
        GetComponent<PanelMenu>().HidePanel();
        panelOpition.ShowPanel();
    }
    public void Credit()
    {       
        GetComponent<PanelMenu>().HidePanel();
        panelCredit.ShowPanel();
    }
    public int[] ToInt(string resolution)
    {
        int[] resInt = new int[2];
        string[] sArray = resolution.Split('*');
        for (int i = 0; i < sArray.Length; i++)
        {
            resInt[i] = int.Parse(sArray[i]);
        }
        return resInt;
    }
    public int ResolutionValue(string resolution)
    {
        int value;
        switch (resolution)
        {
            case "1024*768":
                value = 0;
                break;
            case "768*600":
                value = 1;
                break;
            case "512*400":
                value = 2;
                break;
            default:
                value = 0;
                break;
        }
        return value;
    }
}
