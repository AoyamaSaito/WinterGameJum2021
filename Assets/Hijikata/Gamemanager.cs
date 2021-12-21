using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    /// <summary>ボタンの効果音</summary>
    [SerializeField] AudioSource _audioClip = default;
    [SerializeField] Text _scoreText = default;
    private int totalscore = 0;
    public float _scoreChangeInterval = 0;

    /// <summary>Stage1にシーン切り替え</summary>
    public void Stage1()
    {
        //_audioClip.Play();
        SceneManager.LoadScene("Stage1");
        Debug.Log("Stage1にシーン切り替え");
    }

    /// <summary>Stage2にシーン切り替え</summary>
    public void Stage2()
    {
        //_audioClip.Play();
        SceneManager.LoadScene("");
        Debug.Log("Stage2にシーン切り替え");
    }

    /// <summary>Stage3にシーン切り替え</summary>
    public void Stage3()
    {
        //_audioClip.Play();
        SceneManager.LoadScene("");
        Debug.Log("Stage3にシーン切り替え");
    }

    /// <summary>Titleにシーン切り替え</summary>
    public void Title()
    {
        //_audioClip.Play();
        SceneManager.LoadScene("");
        Debug.Log("タイトルへ");
    }

    /// <summary>GameFinish</summary>
    public void GameFin()
    {
        //_audioClip.Play();
        Application.Quit();
        Debug.Log("ゲーム終了");
    }

    public void AddScore(int score) 
    {
        int previousScore = totalscore;
        totalscore += score;

        DOTween.To(() => previousScore, x =>
        {
            previousScore= x;
            _scoreText.text = previousScore.ToString("00000000");
        }, totalscore, _scoreChangeInterval).OnComplete(() => _scoreText.text = totalscore.ToString("00000000"));
    }

}
