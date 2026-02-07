using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    private GameSave gameSave;

	// Use this for initialization
	void Start () {
        AudioManager.playMenuMusic();
        GameManager.LoadGame();
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitGame() {
        GameManager.SaveGame();
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Level " + GameManager.maxLevel.ToString());
        Time.timeScale = 1;
    }

    public void LoadHowTo() {
        SceneManager.LoadScene("HowTo");
    }

    public void LoadChooseLevel() {
        SceneManager.LoadScene("ChooseLevel");
    }
}
