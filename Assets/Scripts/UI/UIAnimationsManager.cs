using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class UIAnimationsManager : MonoBehaviour
{
    #region Fields

    private RectTransform _endScreen;
    private Vector2 _endScreenStartPosition;

    #endregion
    
    #region Initialization
    private void Start()
    {
        _endScreen = GameObject.Find("EndScreen").GetComponent<RectTransform>();
        _endScreenStartPosition = _endScreen.anchoredPosition;
    }
    
    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GameManager.LevelChanged += Show_endScreen;
        GameManager.BonusLevelEnded += ShowBonusScreen;
    }

    #endregion
    
    #region OnDisable
    private void OnDisable()
    {
        GameManager.LevelChanged -= Show_endScreen;
        GameManager.BonusLevelEnded -= ShowBonusScreen;

    }
    #endregion

    #region Animations
    private void Show_endScreen(bool winner)
    {
        _endScreen.gameObject.SetActive(true);
        _endScreen.DOAnchorPos(Vector2.zero, 0.25f).SetUpdate(true);
    }
    
    private void ShowBonusScreen()
    {
        _endScreen?.gameObject.SetActive(true);
        _endScreen?.DOAnchorPos(Vector2.zero, 0.25f).SetUpdate(true);
    }

    public void Hide_endScreen()
    {
        _endScreen.DOAnchorPos(_endScreenStartPosition, 0.25f).SetUpdate(true);
        _endScreen.gameObject.SetActive(false);
    }
    #endregion
}
