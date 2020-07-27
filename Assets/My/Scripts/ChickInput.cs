using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class ChickInput : MonoBehaviour
{
    // Start is called before the first frame update
    private Chick m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
    public float speed = 10;
    public Slider health;
    public Slider mood;
    Vector3 differ;
    Rigidbody rigidbody;
    float gravityMultiplier = 0.1f;
    private void Start()
    {
        health.value = mood.value = 100;
        rigidbody = GetComponent<Rigidbody>();
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<Chick>();
        differ = Camera.main.transform.position - transform.position;
    }


    private void Update()
    {
        
        if (!m_Jump)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        // read inputs
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        bool crouch = Input.GetKey(KeyCode.C);

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }
#if !MOBILE_INPUT
        // walk speed multiplier
        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

        // pass all parameters to the character control script
        m_Character.Move(m_Move, crouch, m_Jump);

        //
        Vector3 campos = Camera.main.transform.position, pos = transform.position,forward = transform.forward;
        //改变刚体速度来移动
        //rigidbody.velocity = new Vector3(h*speed, Physics.gravity.y*gravityMultiplier , v*speed);
        float absh = Mathf.Abs(h), absv = Mathf.Abs(v),move= absh+absv;
        int sum = 1;
        sum = absv > 0.1 ? (sum+1) : sum;
        sum = absh > 0.1 ? (sum+1) : sum;
        sum = sum > 2 ? 2 : sum;
        //print(sum + " " + move);
        if(move/sum>0.2)
        rigidbody.velocity = new Vector3(speed*forward.x*move/sum,transform.up.y*Physics.gravity.y * gravityMultiplier,
            speed*forward.z*move/sum);

        //print(rigidbody.velocity);

        m_Jump = false;
        float step = speed*speed * Time.deltaTime;
        
        //Camera.main.transform.position=Vector3.MoveTowards(Camera.main.transform.position,transform.position+ differ,5*Time.deltaTime);
        Camera.main.transform.position = new Vector3(Mathf.Lerp(campos.x, pos.x + differ.x, step),
            Mathf.Lerp(campos.y, pos.y + differ.y, step), Mathf.Lerp(campos.z, pos.z + differ.z, step));
    }
}
