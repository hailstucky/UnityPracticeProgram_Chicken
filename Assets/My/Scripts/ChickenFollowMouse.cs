using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFollowMouse : MonoBehaviour
{
    Animator animator;
    CanvasGroup canvasgroup;
    float AnimTime = 0,speed=5;
    public float AnimRange = 8;
    public float AnimThreshold = 2;
    Vector3 mousePosOnScreen,camPos,mousePosInWorld;
    Rigidbody rigidbodyy;
    Vector3 pos,forward;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbodyy = GetComponent<Rigidbody>();
        canvasgroup = GetComponentInChildren<CanvasGroup>();
        canvasgroup.alpha = 0;
        camPos = Camera.main.WorldToScreenPoint(transform.position);
        pos = transform.position;
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
    }
    private void FixedUpdate()
    {
        mousePosOnScreen = Input.mousePosition;
        mousePosOnScreen.z = camPos.z;
        mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
        mousePosInWorld.y = pos.y;
        //print((mousePosInWorld - pos).magnitude);
        if ((mousePosInWorld - pos).magnitude > 2f)//和鼠标距离过近时不旋转以免错误
        {
            transform.LookAt(mousePosInWorld);
            forward = transform.forward;
            if((mousePosInWorld - pos).magnitude > 4f) animator.SetFloat("walk", 2f);
            else animator.SetFloat("walk", 0f);
            //rigidbodyy.velocity = new Vector3(h * speed, Physics.gravity.y, v * speed);
            //rigidbodyy.velocity = new Vector3(forward.x * speed, Physics.gravity.y, -forward.z * speed);
            transform.position= Vector3.MoveTowards(transform.position, mousePosInWorld-forward*2, 3 * Time.deltaTime);
            
        }
        //print("" + animator.GetFloat("walk"));
    }
    void UpdateAnimator()
    {
        AnimTime = Random.Range(AnimThreshold - AnimRange, AnimThreshold + 1);
        animator.SetFloat("time", AnimTime);
    }
}
