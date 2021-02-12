using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields

    private int _playerScore;
    private int _enemyScore;
    private int _playerMoney;
    public static bool isBonusLevel = false;
    [SerializeField] private int requireToBonusLevel;
    [SerializeField] private int playerWinsCount;

    [SerializeField] private int _pointsWhenBonus;
    [SerializeField] [Range(1, 20)] private int _requireToWin;
    public static event Action<bool, int> scoreChanged;
    public static event Action<bool> LevelChanged;
    public static event Action<int, bool> LevelStarted;
    public static event Action LastGoal;
    public static event Action BonusLevelEnded;

    #endregion

    #region Initialization

    private void Awake()
    {
        //LoadProgress
        //PlayerPrefs.DeleteAll();
        playerWinsCount = PlayerPrefs.GetInt("playerWins", 0);
        _playerMoney = PlayerPrefs.GetInt("Money", 0);
        
        //Check if the level is bonus now
        isBonusLevel = playerWinsCount == requireToBonusLevel;
    }

    void Start()
    {
        _playerScore = _enemyScore = 0;

        //Set Points Require To Win
        if(!isBonusLevel) LevelStarted?.Invoke(_requireToWin, isBonusLevel);
        
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
           if (!isBonusLevel)
           {
               _playerScore++;
               if (_playerScore == _requireToWin)
               {
                   playerWinsCount++;
                   PlayerPrefs.SetInt("playerWins", playerWinsCount);
                   LastGoal?.Invoke();
                   LevelChanged?.Invoke(true);
               }
           }
           else
           {
               _playerScore += 3;
           }
           scoreChanged?.Invoke(winner, _playerScore);

       }
       else
       {
           _enemyScore++;
           scoreChanged?.Invoke(winner, _enemyScore);
           if (_enemyScore == _requireToWin)
           {
               LastGoal?.Invoke();
               LevelChanged?.Invoke(false);
           }

       }
   }
   
   #endregion

   #region TimeIsUp

   void ChangeLevelWhenTimeIsUp()
   {
       if (!isBonusLevel)
       {
           if (_playerScore > _enemyScore)
           {
               playerWinsCount++;
               PlayerPrefs.SetInt("playerWins", playerWinsCount);
               LevelChanged?.Invoke(true);
           }
           else
           {
               LevelChanged?.Invoke(false);
           }
       }
       else
       {
           _playerMoney += _playerScore;
           PlayerPrefs.SetInt("Money", _playerMoney);
           playerWinsCount = 0;
           PlayerPrefs.SetInt("playerWins", playerWinsCount);
           BonusLevelEnded?.Invoke();
       }
   }

   #endregion
}
