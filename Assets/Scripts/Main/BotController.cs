﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    #region Fields

    private Vector3 targetPosition;
    private bool _canMove = true;
    [SerializeField] private float _botJumpDelay;
    [SerializeField] private float _botJumpPower;
    private Vector3 _currentPosition;
    private Rigidbody _botRigidbody;

    #endregion

    #region Init

    void Start()
    {
        targetPosition = Vector3.zero;
        _botRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(BotMovement());
    }

    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GameManager.LevelChanged += StopMoving;
    }

    #endregion

    #region OnDisable

    private void OnDisable()
    {
        GameManager.LevelChanged -= StopMoving;
    }

    #endregion

    #region BotControls
    
    void StopMoving(bool temp)
    {
        _canMove = false;
    }

    IEnumerator BotMovement()
    {
        while (_canMove)
        {
            _currentPosition = transform.position;
            if (_currentPosition.y <= targetPosition.y && _currentPosition.x>targetPosition.x)
            {
                _botRigidbody.angularVelocity = Vector3.zero;
                _botRigidbody.AddForce(Vector3.up * _botJumpPower, ForceMode.VelocityChange);
                _botRigidbody.AddForce(Vector3.left * _botJumpPower, ForceMode.VelocityChange);
            }
            else if (_currentPosition.y <= targetPosition.y && _currentPosition.x<targetPosition.x)
            {
                _botRigidbody.angularVelocity = Vector3.zero;
                _botRigidbody.AddForce(Vector3.up * _botJumpPower, ForceMode.VelocityChange);
                _botRigidbody.AddForce(Vector3.right * _botJumpPower, ForceMode.VelocityChange);
            }
            yield return new WaitForSeconds(_botJumpDelay);
        }
    }
    #endregion
}
