using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour {
    private LevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    private Color purple = new Color(120, 0, 255);
    private Color blue = new Color(255, 255, 255);

    private bool open;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        open = levelManager.getReqCoins() == 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (open) {
            spriteRenderer.color = blue;
        } else {
            spriteRenderer.color = purple;
        }

        open = levelManager.getReqCoins() == 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && open) {
            levelManager.enterEndpoint();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && open)
        {
            levelManager.exitEndpoint();
        }
    }
}
