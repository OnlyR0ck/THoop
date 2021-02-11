using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class UpdateEnemyScore : MonoBehaviour
{
    private TextMeshProUGUI _enemyTextScore;
    private RectTransform _enemyTextRectTransform;
    
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _animateColor;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTextScore = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _enemyTextRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
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
        if (!winner)
        {
            _enemyTextScore.text = $"{score}";
            _enemyTextRectTransform.DOScale(1.4f, 0.1f);
            _enemyTextScore.DOColor(_animateColor, 0.1f);
            _enemyTextRectTransform.DOScale(1f, 0.5f);
            _enemyTextScore.DOColor(_startColor, 1f);
        }
    }
}