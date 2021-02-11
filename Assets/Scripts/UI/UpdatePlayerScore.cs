using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePlayerScore : MonoBehaviour
{
    private TextMeshProUGUI _playerTextScore;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerTextScore = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
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
        }
    }
}
