using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BelowShotController : MonoBehaviour
{
    [SerializeField] float shotPower = 5;
    [SerializeField] Transform muzzle;
    [SerializeField] Slider slider;
    [SerializeField] GameObject[] destroys;
    [SerializeField] bool isShot = false;
    [SerializeField] bool isBelow = false;
    [SerializeField , Header("スペースを押した後の重力値")] int newGravity = 0;

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

        if(Input.GetButtonDown("Jump") && isBelow) 
        {
            Below();
        }
    }

    void Shot()
    {
        shotPower *= slider.value;
        Vector2 shotDirection = muzzle.position - gameObject.transform.position;
        rb.AddForce(shotDirection.normalized * shotPower, ForceMode2D.Impulse);
        Array.ForEach(destroys, go => Destroy(go));
        isShot = false;
        isBelow = true;
    }

    public void IsShot()
    {
        isShot = true;
    }

    void Below() 
    {
        isBelow = false;
        rb.velocity = Vector3.zero;
        rb.gravityScale = newGravity;
    }
}
