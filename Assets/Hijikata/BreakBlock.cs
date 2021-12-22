using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    /// <summary>オブジェクトをはこ</summary>
    [SerializeField] GameObject _collsionGameObject = default;
    /// <summary>Blockが壊れるまでの回数</summary>
    [SerializeField] int _breakCount = 3;
    bool _breakInterval = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            _breakCount--;

            if (_breakCount >= 0) Destroy(this.gameObject);
        }
        //_collsionGameObject = collision.gameObject;
        //BlockBreak();
        //PlayerAttackBlock();
    }

    /// <summary>_colsionGameObjectにはいったオブジェクトのタグが"Block"だった時に_breakCountを減らして尚且つ_breakCountが0より小さくなくなった時に壊す</summary>
    void BlockBreak()
    {
        if (_collsionGameObject.tag == "Block" )
        {
            _breakCount--;

            if (_breakCount >= 0) Destroy(this.gameObject);
        }
    }

    /// <summary>_colsionGameObjectにはいったオブジェクトのタグが"Player"だった時に_breakCountを減らして尚且つ_breakCountが0より小さくなくなった時に壊す</summary>
    public void PlayerAttackBlock()
    {
        if (gameObject.tag == "Player")
        {
            _breakCount--;

            if (_breakCount >= 0) Destroy(this.gameObject);
        }
    }
}
