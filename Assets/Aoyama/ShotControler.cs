using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShotControler : MonoBehaviour
{
    [SerializeField] float shotPower = 5;
    [SerializeField] Transform muzzle;
    [SerializeField] Slider slider;
    [SerializeField] GameObject[] destroys;
    [SerializeField] bool isShot = false;
    Bulletlife bulletLife;
    [SerializeField, Header("ブロックに当たった時の処理")] UnityEvent blockEvent;

    GameObject Obj;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Obj = GameObject.Find("Present");
        bulletLife = GameObject.Find("BulletManager").GetComponent<Bulletlife>();

    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && isShot)
        {
            Shot();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            collision.gameObject.GetComponent<BreakBlock>()?.PlayerAttackBlock();
            MineDestroy();
        }
    }

    void Shot()
    {
        shotPower *= slider.value;
        Vector2 shotDirection = muzzle.position - gameObject.transform.position;
        rb.AddForce(shotDirection.normalized * shotPower, ForceMode2D.Impulse);
        Array.ForEach(destroys, go => Destroy(go));
        isShot = false;
    }

    public void IsShot()
    {
        isShot = true;
    }

    void MineDestroy()
    {
        bulletLife.Present();
        Destroy(gameObject);
    }
}
