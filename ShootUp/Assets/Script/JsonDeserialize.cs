using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class JsonDeserialize : MonoBehaviour {    
    private static JsonData config;
    void Awake()
    {
        //LoadConfig();
        //Debug.Log("读取成功！");
        //Debug.Log(GetComponent<Text>().text);
    }
    public void LoadConfig()
    {
        config = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Credit.json", Encoding.GetEncoding("GB2312")));
        
        
        DecodeJson();
    }
    private void DecodeJson()
    {
        for(int i = 0; i < config.Count; i++)
        {
            string version = config[i]["version"].ToString();
            string author = config[i]["author"].ToString();
            string sumary = config[i]["sumary"].ToString();
            GetComponent<Text>().text="Version:  "+version + "\r\n" 
                +"Author:  "+author+"\r\n"
                +"Version Brief:"+"\r\n"+sumary+"\r\n"
                + Application.streamingAssetsPath + "/Credit.json";
        }

    }   

}
