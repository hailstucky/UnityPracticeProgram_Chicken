using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if(collider.tag=="Player")
        {
            if (Input.GetButtonDown("Jump"))
            {

            }

        }
    }
}
