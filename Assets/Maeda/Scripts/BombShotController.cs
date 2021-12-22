using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
