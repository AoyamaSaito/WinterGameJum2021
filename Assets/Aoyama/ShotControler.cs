using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cinemachine;

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

    Vector3 _nowTransform = new Vector3(0,0,0);

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
        if(Input.GetButtonDown("Fire1") && isShot)
        {
            Shot();
        }

        _time += Time.deltaTime;

        if(_time >= 1 && !isShot)
        {          
            if(_nowTransform == gameObject.transform.position)
            {
                MineDestroy();
            }
            _nowTransform = gameObject.transform.position;
            _time = 0;
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
        _farCamera.MoveToTopOfPrioritySubqueue();
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
        _nearCamera.MoveToTopOfPrioritySubqueue();
        Destroy(gameObject);
    }
}
