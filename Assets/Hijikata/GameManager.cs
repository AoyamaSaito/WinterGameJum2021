using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>ボタンの効果音</summary>
    [SerializeField] AudioSource _audioClip = default;
    /// <summary>_gameStartにシーン切り替え</summary>
    [SerializeField] string _gameStart = default;

    public void GameStart()
    {
        _audioClip.Play();
        SceneManager.LoadScene(_gameStart);
        Debug.Log("ゲームスタート");
    }

    public void GameClear()
    {
        _audioClip.Play();
        SceneManager.LoadScene("");
    }
}
