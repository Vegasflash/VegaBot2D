using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool
{
    private string name;
    private string category;

    private GameObject masterPrefab;
    private bool allowRunTimeCreation;

    private ArrayList inUse;
    private ArrayList available;

    public ObjectPool(string name, GameObject masterPrefab, int size, bool allowRunTimeCreation)
    {
        this.name = name;
        this.masterPrefab = masterPrefab;
        this.allowRunTimeCreation = allowRunTimeCreation;

        available = new ArrayList(size);
        inUse = new ArrayList(size);

        for(int i = 0; i < size; i++)
        {


            available.Add(CreateObject(name, masterPrefab));

            //obj.BroadcastMessage("Start", SendMessageOptions.DontRequireReceiver);

        }
    }

    public GameObject GetObject()
    {
        GameObject obj;
        if(available.Count > 0)
        {
            // There is objects available
            obj = available[available.Count - 1] as GameObject;
            available.RemoveAt(available.Count - 1);
        }
        else if(allowRunTimeCreation)
        {
            // Non remaining, and we can create new objects runtime

            obj = CreateObject(name, masterPrefab);
        }
        else
        {
            // None remaining and we cannot create new object runtime...
            // so pick the oldest one in the inUse queue.

            obj = inUse[0] as GameObject;
            inUse.RemoveAt(0);
        }

        if (obj != null)
        {
            inUse.Add(obj);
            obj.SetActive(true);
        }
        return obj;
    }

    public void ReleaseObject(GameObject toRelease)
    {
        inUse.Remove(toRelease); // (index)
        available.Add(toRelease);

        toRelease.SetActive(false);
        toRelease.transform.parent = null;
    }

    public void Destroy()
    {
        foreach(GameObject go in inUse)
        {
            ReleaseObject(go);
        }

        foreach(GameObject go in available)
        {
            GameObject.Destroy(go);
        }
        masterPrefab = null;

        available.Clear();
        available = null;

        inUse.Clear();
        inUse = null;

    }

    private GameObject CreateObject(string name, GameObject masterPrefab)
    {
        GameObject obj = GameObject.Instantiate(masterPrefab) as GameObject;
        obj.name = name;

        obj.SetActive(false);

        obj.BroadcastMessage("Start", SendMessageOptions.DontRequireReceiver);

        return obj;
    }

}
