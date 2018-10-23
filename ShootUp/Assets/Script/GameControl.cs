using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Game=0,
    GameOver,
    Pause,
    Hold,
    Restore
}
public class GameControl : MonoBehaviour {
    static GameControl instance;
    public static GameControl Instance
    {
        get
        {
            if (instance == null) instance = new GameControl();
            return instance;
        }
    }
    public Transform Result;
    public Transform panelContinue;
    //public Transform FinalScore;
    public Text FinalScore;
    Text YourScore;
    public int score;
    AudioSource audioSource;
    public  bool IsPause;
    public GameState gameState;
    void Awake()
    {
        instance = this;
        audioSource = GameObject.Find("AudioControl").GetComponent<AudioSource>();
        //FinalScore = Result.Find("Text").Find("Score").transform;       
        FinalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        YourScore= GameObject.Find("YourScore").GetComponent<Text>();
        Result.GetComponent<PanelResult>().HidePanel();
        panelContinue.GetComponent<PanelContinue>().HidePanel();
        IsPause = false;
    }
    void Update()
    {
        //if(SceneManager.GetActiveScene().name=="Game")
        //RayCast();
    }
    public void GameOver()
    {
        if (gameState == GameState.Game)
        {
            Time.timeScale = 0;
            gameState = GameState.GameOver;
        }        
        audioSource.Stop();
        FinalScore.text =""+ score;
        if (PlayerPrefs.GetInt("Score") < score)
            PlayerPrefs.SetInt("Score", score);
        Result.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        audioSource.Play();
        Time.timeScale = 1;
        this.gameState = GameState.Game;
    }
    public void ExitGame()
    {        
        if (PlayerPrefs.GetInt("Score") < score)
            PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene(0);
    }
    public void Opition()
    {
        Debug.Log("设置面板");
    }
    public void Credit()
    {
        Debug.Log("版本信息");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall") Time.timeScale = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall") Time.timeScale = 1;
    }    
    
    public void Pause()
    {        
        if (gameState==GameState.Game||gameState==GameState.Hold)
        {
            Time.timeScale = 0;
            gameState = GameState.Pause;
        }
    }
    public void Hold()
    {
        if (gameState == GameState.Game)
        {
            Time.timeScale = 0;
            gameState = GameState.Hold;
        }
    }
    public void Restore()
    {
        if (gameState == GameState.Hold)
        {
            Time.timeScale = 1;
            gameState = GameState.Game;
        }
    }

    public void Continue()
    {
        if (gameState == GameState.Pause)
        {
            Time.timeScale = 1;
            gameState = GameState.Game;
        }
    }   
}
