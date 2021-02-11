using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = System.Random;

public class AnnouncersController : MonoBehaviour
{
    private GameObject _announcer;
    private TextMeshProUGUI _announcerText;
    private RectTransform _announcerRectTransform;
    [SerializeField] private float _duration;
    [SerializeField] private Vector2 _moveVector;

    private readonly string[] _announcers = new[] {"SIC!", "AWESOME!", "UNSTOPPABLE!", "COOL!", "OMG!", "LUCKY!", "GODLIKE!"};

    private void Start()
    {
        _announcer = transform.GetChild(0).gameObject;
        _announcerRectTransform = _announcer.GetComponent<RectTransform>();
        _announcerText = _announcer.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GoalController.getHit += ShowAnnouncer;
    }

    private void OnDisable()
    {
        GoalController.getHit -= ShowAnnouncer;
    }

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
        _announcerRectTransform.DOAnchorPos(_moveVector, 1f);
        yield return new WaitForSeconds(_duration);
        _announcer.SetActive(false);
        _announcerRectTransform.DOAnchorPos(Vector2.zero, 0f);

    }
}
