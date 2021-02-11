using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerScore;
    private int _enemyScore;
    [SerializeField] [Range(1, 20)] private int _requireToWin;
    public static event Action<bool, int> scoreChanged;
    
    void Start()
    {
        _playerScore = _enemyScore = 0;
    }

    private void OnEnable()
    {
        GoalController.getHit += UpdateScore;
    }

    private void OnDisable()
    {
        GoalController.getHit -= UpdateScore;
    }

    void Update()
    {
        
    }

    void UpdateScore(bool winner)
    {
        if (winner)
        {
            _playerScore++;
            scoreChanged?.Invoke(winner, _playerScore);
            if (_playerScore == _requireToWin)
            {
                //Win
            }
        }
        else
        {
            _enemyScore++;
            scoreChanged?.Invoke(winner, _enemyScore);
            if (_enemyScore == _requireToWin)
            {
                //Lose
            }
            
        }
    }
}
