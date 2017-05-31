using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDescription
{
    public string name;
    public string category;

    public GameObject masterPrefab;
    public int size;
    public bool allowRuntimeCreation;

    public ObjectPool pool;

    public void Destroy()
    {
        masterPrefab = null;
        if (pool != null)
        {
            pool.Destroy();
        }
    }
}
