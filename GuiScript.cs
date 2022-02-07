using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiScript : MonoBehaviour
{
    GUIStyle labelStyle;
    GUIStyle boxStyle;
    GUIStyle btnStyle;
    string message;
    // Start is called before the first frame update
    void Start()
    {
        message = "新しい一週間が始まりましたね";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GuiSetup()
    {
        boxStyle = new GUIStyle(GUI.skin.box);
        boxStyle.fontSize = 40;
        boxStyle.normal.textColor = Color.white;
        labelStyle = new GUIStyle();
        labelStyle.fontSize = 42;
        labelStyle.normal.textColor = Color.white;
        btnStyle = new GUIStyle(GUI.skin.button);
        btnStyle.fontSize = 42;
        btnStyle.normal.textColor = Color.white;
    }

    void OnGUI()
    {
        GuiSetup();
        GUI.Box(new Rect(200, 800, 2000, 200), "めせんしちゃん", boxStyle);
        GUI.Label(new Rect(235, 850, 2800, 250), message,labelStyle);
        if(GUI.Button(new Rect(2100, 920, 100, 50), "次へ"))
        {
            message = "お仕事に学校、一緒に頑張りましょう！！";
        }
    }
}
