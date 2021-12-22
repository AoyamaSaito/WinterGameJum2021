using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public Text Pausetext;
    public GameObject PausePanel;
    private bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        PausePanel.SetActive(false);
        Pausetext.enabled = false;
    }
    public void PauseButton()
    {
        inGame = false;
        PausePanel.SetActive(true);
        Pausetext.enabled = true;
    }
    public void Back()
    {
        inGame = true;   //すぐに始まってしまう
        PausePanel.SetActive(false);
    }
    public void Retry()
    {

    }
    public void Retire()
    {

    }

}
