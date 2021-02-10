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
    [SerializeField] private bool _enemyAlreadyHit = false;
    private int _playerHits;
    private int _enemyHits;
    
    
    
    public static event Action<int> getHit;


    #endregion
    void Start()
    {
        
        _scoreZone = GetComponent<BoxCollider>();
        _playerHits = _enemyHits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerHits++;
            if (_playerHits == 3 && !_playerAlreadyHit)
            {
                Debug.Log("Player Hit");
                _playerAlreadyHit = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerHits--;
            if (_playerHits == 0) _playerAlreadyHit = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
