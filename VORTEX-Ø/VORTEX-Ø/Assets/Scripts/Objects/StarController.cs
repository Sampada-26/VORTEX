using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            levelManager.starPickup();
        }
    }
}
