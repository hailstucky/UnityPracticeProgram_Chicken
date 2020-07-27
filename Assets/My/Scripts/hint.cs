using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint : MonoBehaviour
{
    float  num, changetime = 0;
    public float UINeededTime = 2;
    public float UIStayTime = 3;
    Text text;
    Image image;
    string textcontent;
    int showing = 0, fading = 0, messageNum = 6;
    public CanvasGroup canvasgroup;
    // Start is called before the first frame update
    void Start()
    {
        ///canvasgroup = GetComponentInChildren<CanvasGroup>();
        canvasgroup.alpha = 0;
        image = canvasgroup.GetComponentInChildren<Image>();
        text = image.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showing > 0 || fading > 0)
        {
            if (fading == 1) changetime -= Time.deltaTime;
            else if (showing == 1) changetime += Time.deltaTime;
            ShowMessage();
        }
    }
    public void ShowMessage()
    {
        showing = 1;
        if (changetime > UINeededTime + UIStayTime) fading = 1;
        if (changetime < 0)
        {
            showing = fading = 0;
            changetime = 0f;
        }
        canvasgroup.alpha = changetime / UINeededTime;

    }
    public void id(int id)
    {
        textcontent = "";
        textcontent += "获得了 ";
        switch (id)
        {
            case 1:
                textcontent += "花";
                break;
            case 2:
                textcontent += "蘑菇";
                break;
            case 3:
                textcontent += "石头";
                break;
            case 4:
                textcontent += "木头";
                break;

        }
        textcontent += " *1";
        text.text = textcontent;
        ShowMessage();
    }
}
