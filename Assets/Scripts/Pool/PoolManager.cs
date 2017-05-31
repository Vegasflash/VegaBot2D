using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager 
    : MonoSingleton<PoolManager>
{
    private List<PoolDescription> pools;


    private void OnAwake()
    {
        
    }

    protected PoolManager()
    {
        pools = new List<PoolDescription>();
    }

    public void AddPool(PoolDescription newPool)
    {
        if(newPool != null && !IsPoolCreated(newPool.name))
        {
            newPool.pool = new ObjectPool(newPool.name, 
                                          newPool.masterPrefab, 
                                          newPool.size, 
                                          newPool.allowRuntimeCreation);
            pools.Add(newPool);
        }
    }

    public void AddPool(PoolDescription[] newPools)
    {
        if(newPools != null)
        {
            foreach(PoolDescription pd in newPools)
            {
                AddPool(pd);
            }
        }
    }

    Predicate<PoolDescription> predicate;


    public bool IsPoolCreated(string name)
    {
        return GetPoolDescription(name) != null;
    }

    public GameObject GetObjectFromPool(string name)
    {
        return GetObjectFromPool(name, null, false);
    }

    public GameObject GetObjectFromPool(string name, bool sendInitMessage)
    {
        return GetObjectFromPool(name, null, sendInitMessage);
    }

    public GameObject GetObjectFromPool(string name, GameObject masterPrefab)
    {
        return GetObjectFromPool(name, masterPrefab, false);
    }

    public GameObject GetObjectFromPool(string name, GameObject masterPrefab, bool sendInitMessage)
    {
        GameObject go = null;

        PoolDescription pd = pools.Find(
            item => String.Compare(item.name, name, 0) == 0);

        if (pd != null)
        {
            go = pd.pool.GetObject();

            if(sendInitMessage)
            {
                go.BroadcastMessage("InitObject", SendMessageOptions.DontRequireReceiver);
            }
            return go;
        }

        // If we get here the pool just doesn't exist ...
        if (masterPrefab != null)
        {
            PoolDescription newPool = new PoolDescription();
            newPool.size = 0;
            newPool.masterPrefab = masterPrefab;
            newPool.name = name;
            newPool.pool = new ObjectPool(name, masterPrefab, 1, true);

            AddPool(newPool);
            go = newPool.pool.GetObject();

            if (sendInitMessage)
            {
                go.BroadcastMessage("InitObject", SendMessageOptions.DontRequireReceiver);
            }

            Debug.LogWarning(name + " wasn't created. Please add a PoolDescription specifying the initial size.");
            return go;
        }
        return null;
    }

    public void ReleaseObjectFromPool(string name, GameObject toReleaseObject)
    {
        ReleaseObjectFromPool(name, toReleaseObject, true);
    }

    public void ReleaseObjectFromPool(string name, GameObject toReleaseObject, bool sendMessage)
            
    {
        if (toReleaseObject != null && sendMessage)
        {
            toReleaseObject.BroadcastMessage("ReleaseObject", SendMessageOptions.DontRequireReceiver);
        }

        PoolDescription pd = GetPoolDescription(name);
        if(pd != null)
        {
            pd.pool.ReleaseObject(toReleaseObject);
            return;
        }
        Debug.LogWarning("PoolManager::ReleaseObjectFromPool -- Can't find the pool: " + name);
    }

    public void RemoveCategory(string category)
    {
        List<PoolDescription> toRemove;

        toRemove = pools.FindAll(pd => String.Compare(pd.category, category, 0) == 0);

        for(int i = 0; i < toRemove.Count; i++)
        {
            toRemove[i].Destroy();
            pools.Remove(toRemove[i]);
        }
    }

    public void Reset()
    {     
        foreach(PoolDescription pd in pools)
        {
            pd.Destroy();
        }
        pools.Clear();
        pools = null;
    }

    private PoolDescription GetPoolDescription(string name)
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if(pools[i].name == name)
            {
                return pools[i];
            }
        }
        return null;
    }
}
