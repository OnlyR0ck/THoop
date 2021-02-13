using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenTitleController : MonoBehaviour
{
    #region Fields

    private TextMeshProUGUI _titleText;


    #endregion

    #region Initialization

    void Start()
    {
        _titleText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GameManager.BonusLevelEnded += SetTitle;
    }

    #endregion

    #region OnDisable

    private void OnDisable()
    {
        GameManager.BonusLevelEnded -= SetTitle;
    }

    #endregion

    #region TitleColor

    private void SetTitle()
    {
        _titleText.color = Color.magenta;
        _titleText.text = "GEM RUSH";
    }

    #endregion
    
}
