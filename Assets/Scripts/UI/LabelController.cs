using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LabelController : MonoBehaviour
{
    private Image _background;
    private TextMeshProUGUI _winText;
    
    // Start is called before the first frame update
    void Start()
    {
        _background = transform.GetChild(0).GetComponent<Image>();
        _winText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameManager.LevelChanged += SetWinner;
        GameManager.BonusLevelEnded += BonusLevel;
    }

    private void OnDisable()
    {
        GameManager.LevelChanged -= SetWinner;
        GameManager.BonusLevelEnded -= BonusLevel;
    }

    //if winner equals true - player win, else enemy
    private void SetWinner(bool winner)
    {
        if (winner)
        {
            _background.color = new Color(0f, 1f, 0f, 0.16f);
            _winText.color = new Color(0f, 1.0f, 0f, 1f);
            _winText.text = "WIN!"; 
        }
        else
        {
            _background.color = new Color(1f, 0f, 0f, 0.16f);
            _winText.color = new Color(1f, 0f, 0f, 1f);
            _winText.text = "LOSE!";
        }
    }

    private void BonusLevel()
    {
        _background.color = new Color(0.9f, 0.16f, 0.71f, 0.16f);
        _winText.color = new Color(0.9f, 0.16f, 0.71f, 1f);
        _winText.text = "COMPLETED!"; 
    }
}
