using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RequireToWinTextController : MonoBehaviour
{
    #region Fields

    private TextMeshProUGUI _requireToWinText;

    #endregion

    #region Initialization

    private void Start()
    {
        _requireToWinText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    #endregion
    
    #region OnEnable

    private void OnEnable()
    {
        GameManager.LevelStarted += SetText;
    }

    #endregion
    
    #region OnDisable

    private void OnDisable()
    {
        GameManager.LevelStarted -= SetText;
    }

    #endregion

    #region SetText

    void SetText(int number, bool active)
    {
        _requireToWinText.text = $"{number}";
        gameObject.SetActive(!active);
    }

    #endregion
    
}
