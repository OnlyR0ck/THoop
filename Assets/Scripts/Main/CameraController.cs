using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] [Range(1,100)] private float _shakePower;

    [SerializeField] [Range(0.1f, 5)] private float _shakeDuration;

    [SerializeField] [Range(1, 100)] private int _vibrato;
    [SerializeField] [Range(1, 90)] private int _randomness;

    private void OnEnable()
    {
        GoalController.getHit += ShakeCamera;
    }
    
    private void OnDisable()
    {
        GoalController.getHit -= ShakeCamera;
    }

    void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }

    void ShakeCamera(bool temp)
    {
        _mainCamera.DOShakeRotation(_shakeDuration, _shakePower, _vibrato, _randomness);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
