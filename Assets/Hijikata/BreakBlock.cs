using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    /// <summary>オブジェクトをはこ</summary>
    GameObject _collsionGameObject = default;
    /// <summary>Blockが壊れるまでの回数</summary>
    [SerializeField] int _breakCount = 3;
    [SerializeField] float _intervalTime = 1f;
    [SerializeField] GameObject _particle = default;
    bool _breakInterval = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_collsionGameObject == null)
        {
            if (collision.gameObject.tag == "Block" && _breakInterval == false)
            {
                _collsionGameObject = collision.gameObject;
                BlockBreak();
                PlayerAttackBlock();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && _breakInterval == false)
        {
            _breakInterval = true;
            StartCoroutine(Interval());
            _breakCount--;

            if (_breakCount <= 0)
            {
                if (_particle)
                {
                    Instantiate(_particle, this.transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);

            }
        }
    }

    /// <summary>_colsionGameObjectにはいったオブジェクトのタグが"Block"だった時に_breakCountを減らして尚且つ_breakCountが0より小さくなくなった時に壊す</summary>
    void BlockBreak()
    {
        if (_collsionGameObject.tag == "Block" && _breakInterval == false)
        {
            _breakInterval = true;
            StartCoroutine(Interval());
            _breakCount--;

            if (_breakCount <= 0)
            {
                if (_particle)
                {
                    Instantiate(_particle, this.transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);

            }
        }
    }

    /// <summary>_colsionGameObjectにはいったオブジェクトのタグが"Player"だった時に_breakCountを減らして尚且つ_breakCountが0より小さくなくなった時に壊す</summary>
    public void PlayerAttackBlock()
    {
        if (gameObject.tag == "Player" && _breakInterval == false)
        {
            _breakInterval = true;
            StartCoroutine(Interval());
            _breakCount--;

            if (_breakCount <= 0)
            {
                if(_particle)
                {
                    Instantiate(_particle, this.transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);
                
            }
        }
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(_intervalTime);
        _breakInterval = false;
    }
}
