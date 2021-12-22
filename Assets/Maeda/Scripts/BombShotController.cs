using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cinemachine;

public class BombShotController : MonoBehaviour
{
    [SerializeField] float shotPower = 5;
    [SerializeField] Transform muzzle;
    [SerializeField] Slider slider;
    [SerializeField] GameObject[] destroys;
    [SerializeField] bool isShot = false;
    [SerializeField] List<GameObject> BlockList = new List<GameObject>();
    [SerializeField, Header("爆発したとき与える速度")] float speed = 0;
    [SerializeField] bool isBomb = false;
    Bulletlife bulletLife;
    [SerializeField, Header("ブロックに当たった時の処理")] UnityEvent blockEvent;
    GameObject Obj;

    Rigidbody2D rb;

    Vector3 _nowTransform = new Vector3(0, 0, 0);

    float _time = 0;

    CinemachineVirtualCamera _nearCamera;
    CinemachineVirtualCamera _farCamera;

    void Start()
    {
        _nearCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        _farCamera = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        rb = GetComponent<Rigidbody2D>();
        Obj = GameObject.Find("Present");
        bulletLife = GameObject.Find("BulletManager").GetComponent<Bulletlife>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isShot == true)
        {
            Shot();
        }
        if (Input.GetButtonDown("Jump") && isBomb)
        {
            Bomb();
        }

        _time += Time.deltaTime;

        if (_time >= 1 && !isShot)
        {
            if (_nowTransform == gameObject.transform.position)
            {
                MineDestroy();
            }
            _nowTransform = gameObject.transform.position;
            _time = 0;
        }
    }

    void Shot()
    {
        shotPower *= slider.value;
        Vector2 shotDirection = muzzle.position - gameObject.transform.position;
        rb.AddForce(shotDirection.normalized * shotPower, ForceMode2D.Impulse);
        Array.ForEach(destroys, go => Destroy(go));
        isShot = false;
        isBomb = true;
    }

    public void IsShot()
    {
        isShot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block" && !BlockList.Contains(collision.gameObject))
        {
            BlockList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            BlockList.Remove(collision.gameObject);      
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            collision.gameObject.GetComponent<BreakBlock>()?.PlayerAttackBlock();
            MineDestroy();
        }
    }

    void Bomb()
    {
        for (int i = 0; i < BlockList.Count; i++)
        {
            Rigidbody2D _rb = BlockList[i].GetComponent<Rigidbody2D>();
            float dx = BlockList[i].transform.position.x - transform.position.x;
            float dy = BlockList[i].transform.position.y - transform.position.y;
            float rad = Mathf.Atan2(dy, dx);
            float vx = Mathf.Cos(Mathf.Deg2Rad * rad);
            float vy = Mathf.Sin(Mathf.Deg2Rad * rad);
            Vector2 v = new Vector2(-vx, vy * 30);
            _rb.AddForceAtPosition(v * speed , _rb.position + new Vector2(1 , 0));
            _rb.gravityScale = 1;
        }
        isBomb = false;
    }

    void MineDestroy()
    {
        bulletLife.Present();
        _nearCamera.MoveToTopOfPrioritySubqueue();
        Destroy(gameObject);
    }
}
