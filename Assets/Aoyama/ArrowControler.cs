using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControler : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1.1f;
    [SerializeField] float upCountRimit = 5f;
    [SerializeField] float dwonCountRimit = 3f;
    [SerializeField] GaugeControler gc;

    bool isUp;
    bool isDown;
    bool isRotate;
    float counter = 0;
    void Start()
    {
        isUp = true;
        isDown = false;
        isRotate = true;
    }

    void Update()
    {
        StopRotate();
    }
    void FixedUpdate()
    {
        if(isRotate)
        {
            MoveArrow();
        }
    }

    void MoveArrow()
    {
        if (isUp)
        {
            Debug.Log("今は上に上がる処理");
            if (counter <= upCountRimit)
            {
                transform.Rotate(0f, 0f, 180.0f * (Time.deltaTime * rotateSpeed));
                counter += Time.deltaTime * rotateSpeed;
            }
            else
            {
                counter = 0;
                isUp = false;
                isDown = true;

            }
        }
        if (isDown)
        {
            Debug.Log("今は下に下がる処理");
            if (counter <= dwonCountRimit)
            {
                transform.Rotate(0f, 0f, -180.0f * (Time.deltaTime * rotateSpeed));
                counter += Time.deltaTime * rotateSpeed;
            }
            else
            {
                counter = 0;
                isUp = true;
                isDown = false;
            }
        }
    }

    /// <summary>
    /// クリックされたら回転を止める
    /// </summary>
    public void StopRotate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            isRotate = false;
            gc.enabled = true;
        }
    }

    /// <summary>
    /// 呼ばれたら回転する
    /// </summary>
    public void OnRotate()
    {
        isRotate = true;
    }

}
