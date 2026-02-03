using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitedAreaController : MonoBehaviour {

    public int initialTimeLeft = 5;
    private int timeLeft;
    public Text text;
    private bool playerInside = false;
    private Collider2D col;
    private bool countingDown = false;
    public GameObject player;
    private LevelManager levelManager;


    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        col = GetComponent<BoxCollider2D>();
        text.text = initialTimeLeft.ToString();
        timeLeft = initialTimeLeft;
    }
	
	// Update is called once per frame
	void Update () {
        if (col.bounds.Contains(player.transform.position)) {
            playerInside = true;
            if (!countingDown) {
                StartCoroutine(countDown());
                countingDown = true;
            }
        } else {
            resetCounter();
        }

	}

    private IEnumerator countDown() {
        while(playerInside) {
            yield return new WaitForSeconds(1);
            if (!playerInside)
                break;
            timeLeft -= 1;
            text.text = timeLeft.ToString();
            if (timeLeft == 0) {
                levelManager.playerDied();
            }
        }
        countingDown = false;
    }

    private void resetCounter()
    {
        playerInside = false;
        timeLeft = initialTimeLeft;
        text.text = initialTimeLeft.ToString();
    }
}
