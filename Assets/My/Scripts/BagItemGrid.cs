using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItemGrid : MonoBehaviour
{
    public int id = 0;
    private bool isTiem = false;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowName(string name)
    {
        text.text = name;
        text.enabled = true;
    }
}
