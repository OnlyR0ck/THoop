using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    #region Fields

    private BoxCollider _scoreZone;
     public Transform _playerTransform;
    [SerializeField] private Vector3 _enemyPosition;
    private bool _playerAlreadyHit = false;
    private bool _enemyAlreadyHit = false;
    
    
    public static event Action<int> getHit;


    #endregion
    void Start()
    {
        
        _scoreZone = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_scoreZone.bounds.Contains(_playerTransform.position) && !_playerAlreadyHit)
        {
            Debug.Log("Player Hit");
            _playerAlreadyHit = true;
        }
        else _playerAlreadyHit = false;
    }
}
