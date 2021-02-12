using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenTitleController : MonoBehaviour
{
    private TextMeshProUGUI _titleText;
    
    
    void Start()
    {
        _titleText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameManager.BonusLevelEnded += SetTitle;
    }

    private void OnDisable()
    {
        GameManager.BonusLevelEnded -= SetTitle;
    }

    private void SetTitle()
    {
        _titleText.color = Color.magenta;
        _titleText.text = "GEM RUSH";
    }
}
