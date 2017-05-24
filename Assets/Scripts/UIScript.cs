using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject windWalker;
    public GameObject ninja;
    public GameObject sage;
    public GameObject warrior;

    public GameObject manaPool;

    public GameObject healthBar;

    void Start()
    {

    }

	void Update ()
    {
        if (windWalker.activeInHierarchy == true || ninja.activeInHierarchy == true || sage.activeInHierarchy == true || warrior.activeInHierarchy == true)
        {
            healthBar.SetActive(true);
            if (sage.activeInHierarchy == true)
            {
                manaPool.SetActive(true);
            }
        }
        else
        {
            healthBar.SetActive(false);
            if (sage.activeInHierarchy == false)
            {
                manaPool.SetActive(false);
            }
        }
    }
}
