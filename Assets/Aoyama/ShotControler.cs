using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotControler : MonoBehaviour
{
    [SerializeField] float shotPower = 5;
    [SerializeField] Transform muzzle;
    [SerializeField] Slider slider;
    [SerializeField] GameObject[] destroys;
    [SerializeField] bool isShot = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && isShot == true)
        {
            Shot();
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
}
