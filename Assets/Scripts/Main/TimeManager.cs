using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _slowdownFactor;
    [SerializeField] [Range(0f, 1f)] private float _speedOfTimeChange;
    [SerializeField] private float _fixedDeltaTime;

    private void Start()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    private void OnEnable()
    {
        LevelTimer.TimerEnded += SlowTime;
        GameManager.LastGoal += SlowTime;
    }

    private void OnDisable()
    {
        LevelTimer.TimerEnded -= SlowTime;
        GameManager.LastGoal -= SlowTime;
    }

    void SlowTime()
    {
        Time.fixedDeltaTime = _fixedDeltaTime;
        StartCoroutine(SlowTimeCoroutine());
    }

    IEnumerator SlowTimeCoroutine()
    {
        while (Time.timeScale > 0)
        {
            Time.timeScale -= _slowdownFactor;
            yield return new WaitForSeconds(_speedOfTimeChange);
        }
    }
    
}
