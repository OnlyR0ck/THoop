using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _slowdownFactor;
    [SerializeField] [Range(0f, 1f)] private float _speedOfTimeChange;
    [SerializeField] private float _fixedDeltaTime;

    #endregion

    #region Initialization

    private void Start()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    #endregion

    #region OnEnable

    private void OnEnable()
    {
        LevelTimer.TimerEnded += SlowTime;
        GameManager.LastGoal += SlowTime;
    }

    #endregion

    #region OnDisable

    private void OnDisable()
    {
        LevelTimer.TimerEnded -= SlowTime;
        GameManager.LastGoal -= SlowTime;
    }

    #endregion

    #region TimeControl
    
    void SlowTime()
    {
        Time.fixedDeltaTime = _fixedDeltaTime;
        StartCoroutine(SlowTimeCoroutine());
    }

    IEnumerator SlowTimeCoroutine()
    {
        while (Time.timeScale > 0.00000001f)
        {
            Time.timeScale /= _slowdownFactor;
            yield return new WaitForSecondsRealtime(_speedOfTimeChange);
        }

        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 0;
    }
    
    #endregion
    
}
