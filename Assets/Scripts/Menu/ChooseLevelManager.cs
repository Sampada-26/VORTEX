using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevelManager : MonoBehaviour {
    public GameObject levels;
    private GameObject[] levelTexts;
    private Image[] levelImages;
    private Button[] levelButtons;
    private GameObject[] stars;

	void Start () {
        levelTexts = new GameObject[levels.transform.childCount];
        levelImages = new Image[levels.transform.childCount];
        stars = new GameObject[levels.transform.childCount];
        levelButtons = new Button[levels.transform.childCount];

        for (int i = 0; i < levels.transform.childCount; i++) {
            GameObject level = levels.transform.GetChild(i).gameObject;
            levelTexts[i] = level.transform.GetChild(1).gameObject;
            stars[i] = level.transform.GetChild(0).gameObject;
            levelImages[i] = level.GetComponent<Image>();
            levelButtons[i] = level.GetComponent<Button>();
                
            stars[i].SetActive(GameManager.stars[i]);
            levelTexts[i].GetComponent<Text>().text = "Level " + (i + 1).ToString();
            int levelIdx = (i + 1);
            levelButtons[i].onClick.AddListener(delegate { LoadLevel(levelIdx); });

            if (GameManager.maxLevel < (i + 1))
            {
                levelButtons[i].enabled = false;
                Color tempColor = levelImages[i].color;
                tempColor.a = 0.4f;
                levelImages[i].color = tempColor;
            }
        }
    }

    void LoadLevel(int levelIdx) {
        SceneManager.LoadScene("Level " + levelIdx);
        Time.timeScale = 1;
    }
}
