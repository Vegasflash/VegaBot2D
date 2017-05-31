using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject windWalker;


    public GameObject manaPool;

    public GameObject healthBar;

    void Start()
    {

    }

	void Update ()
    {
        if (windWalker.activeInHierarchy == true)
        {
            healthBar.SetActive(true);
        }
        else
        {
            healthBar.SetActive(false);
        }
    }
}
