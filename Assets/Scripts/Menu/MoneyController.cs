using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    #region Fields

    private TextMeshProUGUI _moneyText;
    [SerializeField] private int _moneyCount;

    #endregion

    #region Initialization

    void Start()
    {
        _moneyText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _moneyCount = PlayerPrefs.GetInt("Money", 0);
        _moneyText.text = $"{_moneyCount}";
    }

    #endregion
    
}
