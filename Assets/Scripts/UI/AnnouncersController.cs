using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using Random = System.Random;

public class AnnouncersController : MonoBehaviour
{
    #region Fields

    private GameObject _announcer;
    private TextMeshProUGUI _announcerText;
    private RectTransform _announcerRectTransform;
    private Image _announcerBackground;
    [SerializeField] private Color _startBackgroundColor;
    [SerializeField] private Color _endBackgroundColor;
    [SerializeField] private Color _announcerStartColor;
    [SerializeField] private Color _announcerEndColor;
    [SerializeField] private float _duration;
    [SerializeField] private Vector2 _moveVector;

    private readonly string[] _announcers = new[] {"SIC!", "AWESOME!", "UNSTOPPABLE!", "COOL!", "OMG!", "LUCKY!", "GODLIKE!"};
    
    #endregion

    #region Initialization

    private void Start()
    {
        _announcer = transform.GetChild(0).gameObject;
        _announcerRectTransform = _announcer.GetComponent<RectTransform>();
        _announcerText = _announcer.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _announcerBackground = _announcer.transform.GetChild(0).GetComponent<Image>();
    }

    #endregion
    
    #region OnEnable
    
    private void OnEnable()
    {
        GoalController.getHit += ShowAnnouncer;
    }

    #endregion

    #region OnDisable

    private void OnDisable()
    {
        GoalController.getHit -= ShowAnnouncer;
    }


    #endregion
    
    #region AnnouncerControl
    private void ShowAnnouncer(bool winner)
    {
        if (winner)
        {
            StartCoroutine(StartAnnouncer());
        }
    }

    IEnumerator StartAnnouncer()
    {
        if (UnityEngine.Random.Range(0, 2) > 0)
        {
            _moveVector = new Vector2(_moveVector.x * -1, _moveVector.y);
        }
        _announcerText.text = _announcers[UnityEngine.Random.RandomRange(0,_announcers.Length)];
        _announcer.SetActive(true);
        
        //Move Animation
        _announcerRectTransform.DOAnchorPos(_moveVector, 1f).From(Vector2.zero);
        
        //Scale Animation
        _announcerRectTransform.DOScale(1.5f, 1f).From(0.5f);
        
        //Color Animation
        _announcerText.DOColor(_announcerEndColor, 1f).From(_announcerStartColor);
        _announcerBackground.DOColor(_endBackgroundColor, 1f).From(_startBackgroundColor);
        
        yield return new WaitForSeconds(_duration);
        _announcer.SetActive(false);
        
    }
    
    #endregion
}
