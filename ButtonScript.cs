using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject canvas;
    public bool viewCanvas = false;

    //ボタン押下時に、メニュー画面のCanvasの活性・非活性の制御を行う。
    public void OnClick()
    {
        Debug.Log("click!");
        if (viewCanvas)
        {
            canvas.SetActive(false);
            viewCanvas = false;
        }
        else
        {
            canvas.SetActive(true);
            viewCanvas = true;
        }
    }
}
