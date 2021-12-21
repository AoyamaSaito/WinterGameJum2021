using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField, Header("セットするゲームオブジェクト")] GameObject[] _items = default;
    private int Score => _score;

    public int _score = default;

    void GameStart()
    {
        _score = 0;
    }

    public void ScoreChange(int i)
    {
        _score += i;
    }
}
