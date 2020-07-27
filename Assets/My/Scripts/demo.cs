using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demo : MonoBehaviour
{

    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        string path = "flower";
        image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
