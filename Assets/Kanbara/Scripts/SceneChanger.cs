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
    void Start()
    {
        _text.enabled = false;
    }

    void Update()
    {
        
    }

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        _text.enabled = true;
        await Task.Delay(_textDelay);
        SceneManager.LoadScene(_sceneName);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
