using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateEnemyScore : MonoBehaviour
{
    private TextMeshProUGUI _enemyTextScore;

    // Start is called before the first frame update
    void Start()
    {
        _enemyTextScore = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
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
        }
    }
}