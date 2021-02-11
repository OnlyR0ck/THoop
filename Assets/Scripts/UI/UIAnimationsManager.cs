using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIAnimationsManager : MonoBehaviour
{
    
    public RectTransform endScreen;

    private Vector2 _endScreenStartPosition;


    private void Start()
    {
        _endScreenStartPosition = endScreen.anchoredPosition;
    }

    private void OnEnable()
    {
        GameManager.LevelChanged += ShowEndScreen;
    }

    private void OnDisable()
    {
        GameManager.LevelChanged -= ShowEndScreen;
    }

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
}
