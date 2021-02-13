using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class SceneController : MonoBehaviour
{
    #region Fields

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    private GameObject _spherePrefab;
    [SerializeField] private readonly Vector3 _playerSpawnPosition = new Vector3(-0.25f, -2.8f);
    [SerializeField] private readonly Vector3 _enemySpawnPosition = new Vector3(2.5f, -2.8f);
    [SerializeField] private float _xSpawnAxis = 1.5f;
    [SerializeField] private float _ySpawnAxis = 3.0f;


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
        SpawnSphereAtTheStart();
        SpawnPlayers();

    }

    #endregion

    #region Spawners
    void SpawnSphere(bool winner)
    {
        if (GameManager.isBonusLevel)
        {
            _spherePrefab = _pool.GetSphere();
            _spherePrefab.transform.position = GetSpawnPosition();
            _spherePrefab.SetActive(true);
        }
    }

    void SpawnSphereAtTheStart()
    {
        _spherePrefab = _pool.GetSphere();
        _spherePrefab.transform.position = Vector3.zero;
        _spherePrefab.SetActive(true);
    }

    Vector3 GetSpawnPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-_xSpawnAxis, _xSpawnAxis),
            UnityEngine.Random.Range(-_ySpawnAxis, _ySpawnAxis));
    }

    void SpawnPlayers()
    {
        Instantiate(playerPrefab, _playerSpawnPosition, playerPrefab.transform.rotation);
        if (!GameManager.isBonusLevel)
        {
            Instantiate(enemyPrefab, _enemySpawnPosition, enemyPrefab.transform.rotation);
        }
    }
    #endregion

    #region LoadNextScene

    public void LoadAnotherLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);

    }

    #endregion
}
