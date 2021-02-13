using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Fields
    
    private Camera _mainCamera;
    public static bool _enableVibration = true;
    [SerializeField] [Range(1,100)] private float _shakePower;

    [SerializeField] [Range(0.1f, 5)] private float _shakeDuration;

    [SerializeField] [Range(1, 100)] private int _vibrato;
    [SerializeField] [Range(1, 90)] private int _randomness;
    #endregion

    #region Initialization

    void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }

    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GoalController.getHit += ShakeCamera;
    }

    #endregion

    #region OnDisable

    private void OnDisable()
    {
        GoalController.getHit -= ShakeCamera;
    }

    #endregion

    #region Shaking

    void ShakeCamera(bool temp)
    {
        if (_enableVibration)
        {
            Handheld.Vibrate();

        }
        _mainCamera.DOShakeRotation(_shakeDuration, _shakePower, _vibrato, _randomness);
    }

    #endregion
    
    
}
