using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class UpdatePlayerScore : MonoBehaviour
{
    private TextMeshProUGUI _playerTextScore;
    private RectTransform _playerTextRectTransform;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _animateColor;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerTextScore = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _playerTextRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        GameManager.scoreChanged += ChangeScore;
    }

    private void OnDisable()
    {
        GameManager.scoreChanged -= ChangeScore;
    }

    private void ChangeScore(bool winner, int score)
    {
        if (winner)
        {
            _playerTextScore.text = $"{score}";
            _playerTextRectTransform.DOScale(1.4f, 0.1f);
            _playerTextScore.DOColor(_animateColor, 0.1f);
            _playerTextRectTransform.DOScale(1f, 0.5f);
            _playerTextScore.DOColor(_startColor, 1f);

        }
    }
}
