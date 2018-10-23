using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using System.Text;


public class PanelCredit : PanelAbs{
    public Text Credit;
    private static JsonData config;
    int rowLength;
    float rowHeight;   
    float RectHeight;
    private void Awake()
    {
        rowHeight = 40f;
        rowLength = Credit.text.Length;      
        LoadConfig();
    }
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
   
    public void LoadConfig()
    {               
        string JsonName = Application.dataPath + "/StreamingAssets/Credit.json";
        StreamReader sr = new StreamReader(JsonName);
        string str = sr.ReadToEnd();
        config = JsonMapper.ToObject(str);
        DecodeJson();
        RectHeight = ((Credit.text.Length-(Credit.text.Length % rowLength))/ rowLength+2) * rowHeight;
        if (RectHeight < 201f) RectHeight = 180f;
        Credit.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, RectHeight);
    }
    private void DecodeJson()
    {
        for (int i = 0; i < config.Count; i++)
        {
            string version = config[i]["version"].ToString();
            string author = config[i]["author"].ToString();
            string sumary = config[i]["sumary"].ToString();
            Credit.text = "Version:  " + version + "\r\n"
                + "Author:  " + author + "\r\n"
                + "Version Brief:" + "\r\n" + sumary;
        }

    }

}
