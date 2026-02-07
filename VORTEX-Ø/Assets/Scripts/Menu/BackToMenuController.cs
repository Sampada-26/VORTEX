using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(GoToMenu);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
