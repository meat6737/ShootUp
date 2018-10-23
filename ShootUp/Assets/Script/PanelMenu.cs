using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenu : PanelAbs {
    
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
}
