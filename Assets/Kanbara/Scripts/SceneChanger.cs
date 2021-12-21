using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Header("表示するテキスト")] Text _text = default;
    [SerializeField, Header("切り替えたいシーン名")] string _sceneName = default;
    [SerializeField, Header("テキストを表示する時間（ミリ秒）")] int _textDelay = default;
    [SerializeField, Header("接触したときに行動を起こすタグ")] string _triggerTag = default;
    AudioSource _audioSource;

    void Start()
    {
        _text.enabled = false;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != _triggerTag) return;
        if(_text != null)
        {
            _text.enabled = true;
            await Task.Delay(_textDelay);
        }
        _audioSource.Play();
        SceneManager.LoadScene(_sceneName);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
