using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private TextMeshProUGUI _moneyText;

    [SerializeField] private int _moneyCount;
    // Start is called before the first frame update
    void Start()
    {
        _moneyText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _moneyCount = PlayerPrefs.GetInt("Money", 0);
        _moneyText.text = $"{_moneyCount}";

    }
}
