using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chicken : MonoBehaviour
{
    Animator animator;
    float AnimTime = 0,num,changetime=0;
    public float UINeededTime=2;
    public float UIStayTime = 3;
    public float AnimRange=10;
    public float AnimThreshold=2;
    Text text;
    Image image;
    int showing = 0,  fading=0,messageNum=6;
    public bool noCanvas = false;
    CanvasGroup canvasgroup;

    string[] messages =
    {
        "nice weather",
        "hi, chike",
        "how are you",
        "what are you doing",
        "hahahaha",
        "have a nice day"
    };
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (noCanvas == true) return;
        canvasgroup =GetComponentInChildren<CanvasGroup>();
        canvasgroup.alpha = 0;
        image =canvasgroup.GetComponentInChildren<Image>();
        text = image.GetComponentInChildren<Text>();
        //canvas.enabled = false;
        
        //canvas.worldCamera = Camera.main;
        //threshold= animator.GetFloat("threshold");
    }

    // Update is called once per frame
    void Update()
    {
        AnimTime += Time.deltaTime;
        if (AnimTime > 2)
        {
            UpdateAnimator();
            AnimTime = 0;
        }
        if (noCanvas == true) return;
        if (canvasgroup.enabled == true) canvasgroup.transform.rotation = Camera.main.transform.rotation;
        if (showing >0||fading>0)
        {
            if (fading == 1)changetime -= Time.deltaTime;
            //else if(staying==1)
            else if(showing==1)changetime += Time.deltaTime;
            ShowMessage();
        }
    }
    void UpdateAnimator()
    {
        AnimTime = Random.Range(AnimThreshold - AnimRange, AnimThreshold + 1);
        animator.SetFloat("time", AnimTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "Player")
        {
            if (Input.GetButtonDown("Jump"))
            {
                if(showing==0)text.text = messages[Random.Range(0,messageNum)];
                ShowMessage();
            }
        }
    }
    void ShowMessage()
    {
        showing = 1;
        if (changetime > UINeededTime+UIStayTime) fading = 1;
        if (changetime < 0)
        {
            showing = fading = 0;
            changetime = 0f;
        }
        canvasgroup.alpha = changetime / UINeededTime;

    }

}
