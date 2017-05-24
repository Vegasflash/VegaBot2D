using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject windWalkerCam;
    public GameObject ninjaCam;
    public GameObject sageCam;
    public GameObject warriorCam;

    public GameObject windWalker;
    public GameObject ninja;
    public GameObject sage;
    public GameObject warrior;

    public GameObject pauseMenu;

    private bool paused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

	void Update ()
    {
        if(Input.GetKeyDown("p"))
        {
            paused = !paused;
            if(paused == true)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            if(!paused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
        WindWalkerActive();
        WarriorActive();
        NinjaActive();
        SageActive();                                   
    }

    public bool WindWalkerActive()
    {
        if (windWalker.activeInHierarchy == false)
        {
            windWalkerCam.SetActive(false);
        }
        if (windWalker.activeInHierarchy == true)
        {
            windWalkerCam.SetActive(true);
            return true;
        }
        return false;
    }

    public bool NinjaActive()
    {
        if (ninja.activeInHierarchy == false)
        {
            ninjaCam.SetActive(false);
        }
        if (ninja.activeInHierarchy == true)
        {
            ninjaCam.SetActive(true);
            return true;
        }
        return false;
    }

    public bool WarriorActive()
    {
        if (warrior.activeInHierarchy == false)
        {
            warriorCam.SetActive(false);
        }
        if (warrior.activeInHierarchy == true)
        {
            warriorCam.SetActive(true);
            return true;
        }
        return false;
    }

    public bool SageActive()
    {
        if (sage.activeInHierarchy == false)
        {
            sageCam.SetActive(false);
        }
        if (sage.activeInHierarchy == true)
        {
            sageCam.SetActive(true);
            return true;
        }
        return false;
    }

    public void OnPausedResumeClick()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnPausedRetryClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnPauseExitClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
