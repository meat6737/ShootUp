using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {
    static ColorManager instance;
    public static ColorManager Instance
    {
        get
        {
            if (instance == null) instance = new ColorManager();
            return instance;
        }
    }
    public List<Color> colorList;
    void Awake()
    {
        colorList = new List<Color>();
        Color color1= new Color(166f / 255f, 99f / 255f, 168f / 255f);
        Color color2 = new Color(99f / 255f, 115f / 255f, 168f / 255f);
        Color color3 = new Color(134f / 255f, 168f / 255f, 99f / 255f);
        Color color4 = new Color(99f / 255f, 168f / 255f, 152f / 255f);
        Color color5 = new Color(168f / 255f, 102f / 255f, 99f / 255f);
        colorList.Add(color1);
        colorList.Add(color2);
        colorList.Add(color3);
        colorList.Add(color4);
        colorList.Add(color5);
    }
}
