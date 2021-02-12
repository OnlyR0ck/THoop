using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIAnimationsManager : MonoBehaviour
{
    #region Fields

    public RectTransform endScreen;
    private Vector2 _endScreenStartPosition;

    #endregion
    
    #region Initialization
    private void Start()
    {
        _endScreenStartPosition = endScreen.anchoredPosition;
    }
    
    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GameManager.LevelChanged += ShowEndScreen;
    }

    #endregion
    
    #region OnDisable
    private void OnDisable()
    {
        GameManager.LevelChanged -= ShowEndScreen;
    }
    #endregion

    #region Animations
    private void ShowEndScreen(bool winner)
    {
        endScreen.gameObject.SetActive(true);
        endScreen.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void HideEndScreen()
    {
        endScreen.DOAnchorPos(_endScreenStartPosition, 0.25f);
        endScreen.gameObject.SetActive(false);
    }
    #endregion
}
