using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Header("切り替えたいシーン名")] string _sceneName = default;
    [SerializeField, Header("接触したときに行動を起こすタグ")] string _triggerTag = default;
    [SerializeField, Header("表示するパネル(クリア)")] GameObject _clearPanel;
    [SerializeField, Header("表示するパネル(ゲームオーバー)")] GameObject _gameOverPanel;
    [SerializeField, Header("")] Bulletlife _bulletLife = default;

    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _clearPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != _triggerTag) return;
        _audioSource.Play();
        _bulletLife._isNotPlayGame = true;
        Debug.Log("true");
        _clearPanel.SetActive(true);
        //SceneManager.LoadScene(_sceneName);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }
}
