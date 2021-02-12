using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    #region Fields
    
    [SerializeField][Range(0, 59)] private int _minutes;
    [SerializeField][Range(0, 59)] private int _seconds;

    private TextMeshProUGUI _timerText;
    
    //Events
    public static event Action TimerEnded;
    
    //Properties
    public int Minutes 
    {
        get => _minutes;

        set
        {
            if (value > 0 && value < 60)
            {
                _minutes = value;
            }
        }
        
    }
    public int Seconds
    {
        get => _seconds;
        set
        {
            if (value > 0 && value < 60)
            {
                _seconds = value;
            }
        }
    }

    #endregion

    #region Initialization

    private void Start()
    {
        
        _timerText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
        if (GameManager.isBonusLevel)
        {
            _minutes = 1;
            _seconds = 0;
        }
        
        StartCoroutine(StartTimer());
    }

    #endregion
    

    #region TimerCoroutine

    IEnumerator StartTimer()
    {
        while (_minutes > 0 || _seconds > 0)
        {
            yield return new WaitForSeconds(1);
            if (_seconds == 0)
            {
                _minutes--;
                _seconds = 59;
                UpdateTimerText();
            }
            _seconds--;
            UpdateTimerText();
        }
        TimerEnded?.Invoke();
    }

    #endregion

    #region TimerText

    void UpdateTimerText()
    {
        if (_minutes < 10)
        {
            _timerText.text = _seconds < 10 ? $"0{_minutes}:0{_seconds}" : $"0{_minutes}:{_seconds}";
        }
        else
        {
            _timerText.text = _seconds < 10 ? $"{_minutes}:0{_seconds}" : $"{_minutes}:{_seconds}";

        }
    }

    #endregion
}
