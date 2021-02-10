using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    #region Fields

    public List<GameObject> prefabsToSpawn;
    public GameObject objectToPool;
    public int amountPool;

    #endregion

    #region PoolInitialization

    void Start()
    {
        prefabsToSpawn = new List<GameObject>();
        for (int i = 0; i < amountPool; i++)
        {
            GameObject temp = (GameObject) Instantiate(objectToPool, this.transform, true);
            prefabsToSpawn.Add(temp);
            temp.SetActive(false);
        }
    }

    #endregion

    #region GetObjectMethod

    public GameObject GetSphere()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (!prefabsToSpawn[i].gameObject.activeInHierarchy)
            {
                return prefabsToSpawn[i];
            }
        }
        return null;
    }

    #endregion
}