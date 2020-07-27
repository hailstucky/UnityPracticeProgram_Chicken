using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BagItem : MonoBehaviour
{
    public int id = 0;
    int num = 0;
    Text itemnum;
    string textname="";
    ObjectInfo.Infos  info = null;
    BagItemGrid parent;
    //Canvas parent;
    Image image;
    Vector3 ChangPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        image = GetComponent<Image>() as Image;
        itemnum = GetComponentInChildren<Text>();//取到了
        parent = GetComponentInParent<BagItemGrid>();
    }
    // Update is called once per frame
    void Update()
    {
        if (num == 0)
        { itemnum.enabled = false; }// textname.enabled = false; }
        else { itemnum.enabled = true; }// textname.enabled = true;  }
    }
    public void SetId(int id)
    {
        this.id = id;
        num = 1;
        info =ObjectInfo.instance.GetObjectInfoById(id);
        print(info.iconname);
        this.SetIconName(info.iconname);
        SetImg();
        //itemnum.gameObject.SetActive(true);
        itemnum.text = num.ToString();
        textname = image.name;
        parent.ShowName(image.name);
    }
    public void SetImg()
    {
        string path = info.iconname;
        image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        
    }
    public void add()
    {
        num++;
        itemnum.text = num.ToString();
    }
    public void ClearInfo()
    {
        id = 0;
        info = null;
        num = 0;
        GameObject.Destroy(this, 0);
    }
    public void SetIconName(string iconname)
    {
        image.name = iconname;
    }
}
