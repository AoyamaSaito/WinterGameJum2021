using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ItemBase
{
    [SerializeField, Header("追加するスコア")] int _addScore = default;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _triggerTag)
        {
            ScoreChange(_addScore);
            Destroy(this.gameObject);
        }
    }
}
