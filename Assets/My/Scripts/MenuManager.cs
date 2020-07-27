using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public Canvas canvas;
    Button board;
    Button back;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowHelpBoard()
    {
        canvas.enabled = true;

    }
    public void Back()
    {
        canvas.enabled = false;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
