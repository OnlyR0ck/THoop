using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class UpdatePlayerScore : MonoBehaviour
{
    #region Fields

    private TextMeshProUGUI _playerTextScore;
    private RectTransform _playerTextRectTransform;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _animateColor;

    #endregion

    #region Initialization

    void Start()
    {
        _playerTextScore = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _playerTextRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
    }

    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GameManager.scoreChanged += ChangeScore;
    }

    #endregion

    #region OnDisable

    private void OnDisable()
    {
        GameManager.scoreChanged -= ChangeScore;
    }

    #endregion

    #region ChangeScore

    private void ChangeScore(bool winner, int score)
    {
        if (winner)
        {
            _playerTextScore.text = $"{score}";
            _playerTextRectTransform.DOScale(1.4f, 0.1f);
            _playerTextScore.DOColor(_animateColor, 0.0f);
            _playerTextRectTransform.DOScale(1f, 0.5f);
            _playerTextScore.DOColor(_startColor, 3f);

        }
    }

    #endregion
   
}
