using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelContinue : PanelAbs {   
    public Text score;
    void Update()
    {
        score.text = GameControl.Instance.score.ToString();
    }
    public override void ShowPanel(CallBackShowPanel callback = null)
    {
        Show = true;
        gameObject.SetActive(true);
        score.text = GameControl.Instance.score.ToString();
    }
    public override void HidePanel(CallBackHidePanel callback = null)
    {
        Show = false;
        gameObject.SetActive(false);
    } 
}
