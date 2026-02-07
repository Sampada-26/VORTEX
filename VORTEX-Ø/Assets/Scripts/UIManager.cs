using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject deathScreen;
    public GameObject pauseScreen;
    public GameObject endScreen;
    private GameObject deathCount;

	void Start () {
        deathScreen.SetActive(false);
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
        deathCount = GameObject.FindGameObjectWithTag("DeathCount");
    }
	
	void Update () {
        if (Input.GetKeyDown("escape") && !deathScreen.activeSelf && !endScreen.activeSelf)
        {
            pauseControl();
        }
        deathCount.GetComponent<Text>().text = "Deaths: " + GameManager.deaths.ToString();
    }

	public void showDeathScreen(bool show){
        deathScreen.SetActive(show);
    }

	public void showPauseScreen(bool show){

        pauseScreen.SetActive(show);
    }

	public void pauseControl(){
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPauseScreen(true);
        } else if (Time.timeScale == 0){
            Time.timeScale = 1;
            showPauseScreen(false);
        }
    }

	public void loadMenu() { 
		SceneManager.LoadScene("Menu");
	}

    public void endGame() {
        Time.timeScale = 0;
        endScreen.SetActive(true);
    }
}
