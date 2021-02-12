using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    #region Fields

    private bool _playerAlreadyHit = false;
    private bool _enemyAlreadyHit = false;
    [SerializeField]private int _playerHits;
    private int _enemyHits;
    
    public static event Action<bool> getHit;


    #endregion

    #region Initialization

    void Start()
    {
        _playerHits = _enemyHits = 0;
    }

    #endregion

    #region TrackHits
    
    private void OnTriggerEnter(Collider other)
    {
        //When the player hits goal event invoked with a true parameter, else with false
        if (other.gameObject.CompareTag("Player"))
        {
            _playerHits++;
            if (_playerHits == 3 && !_playerAlreadyHit)
            {
                Debug.Log("Player Hit");
                _playerAlreadyHit = true;
                getHit?.Invoke(true);
                if (GameManager.isBonusLevel)
                {
                    _playerHits = 0;
                    _playerAlreadyHit = false;
                    this.gameObject.SetActive(false);
                }
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            _enemyHits++;
            if (_enemyHits == 3 && !_enemyAlreadyHit)
            {
                Debug.Log("Enemy Hit");
                _enemyAlreadyHit = true;
                getHit?.Invoke(false);
                if (GameManager.isBonusLevel)
                {
                    this.gameObject.SetActive(false);
                }
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            _enemyHits--;
            if (_enemyHits == 0) _enemyAlreadyHit = false;
        }
    }
    
    #endregion
}
