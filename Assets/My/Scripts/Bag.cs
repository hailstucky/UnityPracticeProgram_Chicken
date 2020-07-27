using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    //可以放的物品种类数
    public List<BagItemGrid> ItemList = new List<BagItemGrid>();
     BagItem bagItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetId(int id)
    {
        BagItemGrid grid = null;
        foreach (BagItemGrid t in ItemList)
        {
            if (t.id==id)
            {
                grid = t;break;
            }

        }
        if (grid != null)
        {
            BagItem item = grid.GetComponentInChildren<BagItem>();
            item.add();
        }
        else
        {
            foreach (BagItemGrid t in ItemList)
            {
                if (t.id == 0)
                {
                    grid = t;break;
                }
            }
            if (grid != null)
            {
                /*bagItem = (BagItem)Instantiate(bagItem, Vector3.zero, transform.rotation);
                bagItem.transform.parent = grid.transform;

                bagItem.transform.localPosition = Vector3.zero;*/
                bagItem = grid.GetComponentInChildren<BagItem>();
                grid.id = id;
                bagItem.SetId(id);

            }
        }
    }
}
