using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Header("切り替えたいシーン名")] string _sceneName = default;
    [SerializeField, Header("接触したときに行動を起こすタグ")] string _triggerTag = default;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != _triggerTag) return;
        _audioSource.Play();
        SceneManager.LoadScene(_sceneName);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
