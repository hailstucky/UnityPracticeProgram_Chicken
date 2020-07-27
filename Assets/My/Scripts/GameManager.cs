using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas helpBoard;
    public Canvas bag;
    // Start is called before the first frame update
    void Start()
    {
        helpBoard.enabled = false;
        bag.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowHelpBoard()
    {
        helpBoard.enabled = true;

    }
    public void BackHelp()
    {
        helpBoard.enabled = false;
    }
    public void ShowBag()
    {
        if(helpBoard.enabled==false)
        bag.enabled = true;
    }
    public void BackBag()
    {
        bag.enabled = false;
    }
}
