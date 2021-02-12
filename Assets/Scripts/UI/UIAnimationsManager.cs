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
    [SerializeField] private float _delay;

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
        GameManager.LevelChanged += ShowEndScreen;
        GameManager.BonusLevelEnded += ShowBonusScreen;
    }

    #endregion
    
    #region OnDisable
    private void OnDisable()
    {
        GameManager.LevelChanged -= ShowEndScreen;
        GameManager.BonusLevelEnded -= ShowBonusScreen;

    }
    #endregion

    #region Animations

    void ShowEndScreen(bool screen)
    {
        StartCoroutine(ShowEndScreenCoroutine());
    }
    
    private IEnumerator ShowEndScreenCoroutine()
    {
        yield return new WaitForSecondsRealtime(_delay);
        _endScreen.gameObject.SetActive(true);
        _endScreen.DOAnchorPos(Vector2.zero, 0.25f).SetUpdate(true);
    }

    private void ShowBonusScreen()
    {
        StartCoroutine(ShowBonusScreenCoroutine());
    }
    
    private IEnumerator ShowBonusScreenCoroutine()
    {
        yield return new WaitForSecondsRealtime(_delay);
        _endScreen?.gameObject.SetActive(true);
        _endScreen?.DOAnchorPos(Vector2.zero, 0.25f).SetUpdate(true);
    }

    public void HideEndScreen()
    {
        _endScreen.DOAnchorPos(_endScreenStartPosition, 0.25f).SetUpdate(true);
        _endScreen.gameObject.SetActive(false);
    }
    #endregion
}
