using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public enum ObjectType
    {
        flower,
        tree,
        grass
    }
    public class Infos
    {
        public int id;
        public string name;
        public string iconname;
        public ObjectType type;
    }
    
    public static ObjectInfo instance;
    public TextAsset InfoListText;
    Dictionary<int, Infos> Dic = new Dictionary<int, Infos>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ReadInfo();
        //print(Dic.Keys.Count);
    }
    private void Awake()
    {
        instance = this;
        //ReadInfo();
    }
    public Infos GetObjectInfoById(int id)
    {
        Infos info = null;
        Dic.TryGetValue(id, out info);
        //info.id = Dic[id].id;
        //info.iconname = Dic[id].iconname;
        //print(info.iconname);
        return info;
    }
    void ReadInfo()
    {
        string text = InfoListText.text;
        string[] strArray = text.Split('\n');

        foreach (string str in strArray)
        {
            string[] proArray = str.Split(',');
            Infos info = new Infos();
            int id = int.Parse(proArray[0]);//string to int
            string name = proArray[1];
            string iconname = proArray[2];
            string strType = proArray[3];

            ObjectType type = ObjectType.tree;
            switch (strType)
            {
                case "flower":
                    type = ObjectType.flower;
                    break;
                case "grass":
                    type = ObjectType.grass;
                    break;
                case "tree":
                    type = ObjectType.tree;
                    break;

            }
            info.id = id;
            info.name = name;
            info.iconname = iconname;
            info.type = type;
            //print(id + name + iconname + type);

            Dic.Add(id, info);
         //
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
