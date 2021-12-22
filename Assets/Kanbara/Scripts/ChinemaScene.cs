using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChinemaScene : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _nearCamera;
    [SerializeField] CinemachineVirtualCamera _farCamera;

    bool _isFar = default;
    int priority = 10;
    void Start()
    {
        _isFar = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (!_isFar)
            {
                _farCamera.MoveToTopOfPrioritySubqueue();
                _isFar = true;
            }
            else
            {
                _nearCamera.MoveToTopOfPrioritySubqueue();
                _isFar = false;
            }
        }
    }
    
}
