using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    PlayerCam pCam;

    Scene currentScene;

    public GameObject[] characterList;
    public GameObject Ninja;
    public GameObject Warrior;
    public GameObject Sage;
    public GameObject WindWalker;

    int id;
	// Use this for initialization
	void Start ()
    {
        id = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];
        // Create a list of the game objects
        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        // Deactivate the Game Objects
        foreach(GameObject gObject in characterList)
        {
            gObject.SetActive(false);
        }

        // Turn on the selected character
        if (characterList[id])
        {
            characterList[id].SetActive(true);
        }
	}

    void Update()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 1)
        {
            if (Input.GetMouseButton(0))
                transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X"), 0f));
        }
    }

    public void PreviousCharacter()
    {
        // Toggle off the current model
        characterList[id].SetActive(false);
        id--;
        if(id < 0)
        {
            id = characterList.Length - 1;
        }
        Debug.Log(characterList[id]);
        // Toggle on the new model
        characterList[id].SetActive(true);
    }

    public void NextCharacter()
    {
        // Toggle off the current model
        characterList[id].SetActive(false);
        id++;
        if (id == characterList.Length)
        {
            id = 0;
        }
        Debug.Log(characterList[id]);
        // Toggle on the new model
        characterList[id].SetActive(true);
    }

    public void ConfirmCharacter()
    {
        PlayerPrefs.SetInt("CharacterSelected", id);
        SceneManager.LoadScene("Game");
    }
}
