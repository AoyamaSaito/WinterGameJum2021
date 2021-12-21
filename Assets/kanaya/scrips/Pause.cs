using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    private bool inGame;
    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        PausePanel.SetActive(false);
    }
    public void PauseButton()
    {
        inGame = false;
        PausePanel.SetActive(true);
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
