using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    #region Fields

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject spherePrefab;
    [SerializeField] private readonly Vector3 _playerSpawnPosition = new Vector3(-1.5f, -2.8f);
    [SerializeField] private readonly Vector3 _enemySpawnPosition = new Vector3(1.5f, -2.8f);

    private ObjectPooling _pool;

    #endregion

    #region OnEnable

    private void OnEnable()
    {
        GoalController.getHit += SpawnSphere;
    }

    #endregion

    #region OnDisable

    private void OnDisable()
    {
        GoalController.getHit -= SpawnSphere;
    }

    #endregion

    #region Initialization

    void Start()
    {
        _pool = GetComponent<ObjectPooling>();

    }

    #endregion

    void SpawnSphere(bool winner)
    {
        
    }
}
