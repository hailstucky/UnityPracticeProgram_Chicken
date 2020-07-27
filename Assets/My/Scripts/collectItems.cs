using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectItems : MonoBehaviour
{
    public Bag bag;
    hint _hint;
    // Start is called before the first frame update
    void Start()
    {
        _hint = GetComponent<hint>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionStay(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if (Input.GetButtonDown("Jump"))
        {
            //print(collider.tag);
            switch (collider.tag)
            {
                case "flower":
                    bag.GetId(1);
                    _hint.id(1);
                    break;
                case "mushroom":
                    bag.GetId(2);
                    _hint.id(2);
                    break;
                case "rock":
                    bag.GetId(3);
                    _hint.id(3);
                    break;
                case "wood":
                    bag.GetId(4);
                    _hint.id(4);
                    break;
            }
        }
    }
}
