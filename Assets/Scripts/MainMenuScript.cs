using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void OnNewGameClick()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
