using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    [SerializeField] Text Pausetext;
    [SerializeField] GameObject PausePanel;
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
    public void Back() //ポーズ画面を閉じる
    {
        inGame = true;   //すぐに始まってしまう
        PausePanel.SetActive(false);
    }
    public void Retry() //やり直す
    {
        
    }
    public void Retire()　//諦める
    {

    }

}
