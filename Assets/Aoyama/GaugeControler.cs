﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeControler : MonoBehaviour
{
    Slider slider;

    bool isUp;
    bool isDown;
    bool isMove;

    float counter = 0;
    float upRimit = 1f;
    float dwonRimit = 1f;

    [SerializeField] float moveSpeed = 1.1f;
    [SerializeField] ShotControler sc;
    void Start()
    {
        slider = GetComponent<Slider>();
        dwonRimit = slider.minValue;
        upRimit = slider.maxValue;

        isUp = true;
        isDown = false;
        isMove = true;
    }

    void Update()
    {
        StopGauge();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMove)
        {
            MoveGauge();
        }
    }

    void MoveGauge()
    {
        if (isUp)
        {
            Debug.Log("今は上に上がる処理");
            if (counter < upRimit)
            {
                slider.value += Time.deltaTime * moveSpeed;
                counter += Time.deltaTime * moveSpeed;
            }
            else
            {
                isUp = false;
                isDown = true;

            }
        }
        if (isDown)
        {
            Debug.Log("今は下に下がる処理");
            if (counter > dwonRimit)
            {
                slider.value -= Time.deltaTime * moveSpeed;
                counter -= Time.deltaTime * moveSpeed;
            }
            else
            {
                isUp = true;
                isDown = false;
            }
        }
    }

    public void StopGauge()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           isMove  = false;
            sc.enabled = true;
        }
    }

    public void OnGauge()
    {
        isMove = true;
    }
}