using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField, Header("接触したときに行動を起こすタグ")] public string _triggerTag = default;

    private int Score => _score;

    public int _score = default;

    bool _isFirst = default;
    void Start()
    {
        if (_isFirst) return;
        _score = 0;
        _isFirst = true;
    }

    public void ScoreChange(int i)
    {
        _score += i;
    }
}
