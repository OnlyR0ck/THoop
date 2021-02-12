using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields

    private int _playerScore;
    private int _enemyScore;
    public static bool isBonusLevel = false;
    public static readonly int requireToBonusLevel;
    public static int playerWinsCount;

    [SerializeField] [Range(1, 20)] private int _requireToWin;
    public static event Action<bool, int> scoreChanged;
    public static event Action<bool> LevelChanged;
    public static event Action<int> LevelStarted;

    #endregion

    #region Initialization

    void Start()
    {
        _playerScore = _enemyScore = 0;
        
        //LoadProgress
        playerWinsCount = PlayerPrefs.GetInt("playerWins", 0);
        
        //Set Points Require To Win
        LevelStarted?.Invoke(_requireToWin);
        
    }

    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GoalController.getHit += UpdateScore;
        LevelTimer.TimerEnded += ChangeLevelWhenTimeIsUp;
    }

    #endregion
    
    #region OnDisable
    
    private void OnDisable()
    {
        GoalController.getHit -= UpdateScore;
        LevelTimer.TimerEnded -= ChangeLevelWhenTimeIsUp;

    }
    
    #endregion
    
    #region UpdateScore
   void UpdateScore(bool winner)
   {
       if (winner)
       {
           _playerScore++;
           scoreChanged?.Invoke(winner, _playerScore);
           if (_playerScore == _requireToWin)
           {
               playerWinsCount++;
               PlayerPrefs.SetInt("playerWins", playerWinsCount);
               LevelChanged?.Invoke(true);
           }
       }
       else
       {
           _enemyScore++;
           scoreChanged?.Invoke(winner, _enemyScore);
           if (_enemyScore == _requireToWin)
           {
               LevelChanged?.Invoke(false);
           }

       }
   }
   
   #endregion

   #region TimeIsUp

   void ChangeLevelWhenTimeIsUp()
   {
       if (_playerScore > _enemyScore)
       {
           LevelChanged?.Invoke(true);
       }
       else
       {
           LevelChanged?.Invoke(false);
       }
   }

   #endregion
}
