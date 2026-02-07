using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private int currLevel;
    private int reqCoins;
    private int reqEndpoints;
    private bool pickedupStar;

    private GameObject[] endPoints;
    public GameObject UI;
    private GameObject[] players;

    void Start () {
        string sceneName = SceneManager.GetActiveScene().name;
        currLevel = (int)char.GetNumericValue(sceneName[sceneName.Length - 1]);
        AudioManager.changeMusic(currLevel);
        players = GameObject.FindGameObjectsWithTag("Player");

        reqCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        reqEndpoints = GameObject.FindGameObjectsWithTag("Endpoint").Length;
    }
	
	void Update () {
        GameObject deathScreen = UI.GetComponent<UIManager>().deathScreen;
        if ((Input.GetKeyDown("return") || Input.GetKeyDown("space")) && deathScreen.activeSelf)
        {
            restartLevel();
        }
    }

    public void playerDied() {
        foreach (GameObject player in players)
        {
            player.GetComponent<SpriteRenderer>().enabled = false;
        }
        GameManager.deaths++;
        UI.GetComponent<UIManager>().showDeathScreen(true);
        Time.timeScale = 0;
    }

    public void restartLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void changeLevel() {
        int nextLevel = currLevel + 1;
        string nextSceneName = "Level " + nextLevel.ToString();
        GameManager.stars[currLevel - 1] = pickedupStar;
        if (Application.CanStreamedLevelBeLoaded(nextSceneName)) {
            if (nextLevel > GameManager.maxLevel)
                GameManager.maxLevel = nextLevel;
            SceneManager.LoadScene(nextSceneName);
        } else {
            UI.GetComponent<UIManager>().endGame();
        }
        GameManager.SaveGame();
    }

    public void coinPickup() {
        reqCoins--;
    }

    public void starPickup() {
        pickedupStar = true;
    }

    public int getReqCoins() {
        return reqCoins;
    }

    public void enterEndpoint()
    {
        reqEndpoints--;
        if (reqEndpoints == 0) {
            changeLevel();
        }
    }

    public void exitEndpoint()
    {
        reqEndpoints++;
    }

}
