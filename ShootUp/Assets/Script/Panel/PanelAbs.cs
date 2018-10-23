using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelAbs : MonoBehaviour {
    public delegate void CallBackShowPanel();
    public delegate void CallBackHidePanel();
    public bool Show;
    public abstract void ShowPanel(CallBackShowPanel callback = null);
    public abstract void HidePanel(CallBackHidePanel callback = null);
    public int[] ToInt(string resolution)
    {
        int[] resInt=new int[2];
        string[] sArray=resolution.Split('*');
        for(int i=0;i<sArray.Length;i++)
        {
            resInt[i] = int.Parse(sArray[i]);
        }
        return resInt;
    }
}
