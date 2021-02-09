using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Vector3 _mousePosition;
    private Rigidbody _playerRigidbody;
    [Range(1, 20)][SerializeField] private float _jumpPower;
    private float _middleOfTheScreen;
    private short _directionUnit;
    

    #endregion
    
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _middleOfTheScreen = Screen.width / 2;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _mousePosition = Input.mousePosition;
            if (_mousePosition.x > _middleOfTheScreen)
            {
                _directionUnit = 1;
            }
            else
            {
                _directionUnit = -1;
            }

            _playerRigidbody.velocity = Vector3.zero;
            _playerRigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.VelocityChange);
            _playerRigidbody.AddForce(Vector3.right * (_jumpPower / 2 * _directionUnit), ForceMode.VelocityChange);
        }

    }
}
