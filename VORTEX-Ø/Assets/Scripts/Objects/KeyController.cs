using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
	//private LevelManager levelManager;
	public GameObject door;
	private SpriteRenderer spriteRenderer;
	private PolygonCollider2D col;
	private float doorSpeed = 2;
    public Vector2 doorInitialDirection;
    Rigidbody2D doorRig2D;
	private Vector2 initialDoorPos;
    private bool doorOpen;
    private Vector3 doorSize;

	

	// Use this for initialization
	void Start () {
		//levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		this.col = GetComponent<PolygonCollider2D>();
		
        doorRig2D = door.GetComponent<Rigidbody2D>();
        initialDoorPos = door.transform.position;
        doorSize = door.GetComponent<PolygonCollider2D>().bounds.size;
		doorOpen = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (!doorOpen) {
            if (doorInitialDirection.y == 1 && door.transform.position.y >= initialDoorPos.y + doorSize.y)
            {
                stopDoor();
            }
            else if (doorInitialDirection.y == -1 && door.transform.position.y <= initialDoorPos.y - doorSize.y)
            {
                stopDoor();
            }
            else if (doorInitialDirection.x == 1 && door.transform.position.x >= initialDoorPos.x + doorSize.x)
            {
                stopDoor();
            }
            else if (doorInitialDirection.x == -1 && door.transform.position.x <= initialDoorPos.x - doorSize.x)
            {
                stopDoor();
            }
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
			spriteRenderer.enabled = false;
			col.enabled = false;
            doorRig2D.linearVelocity = doorInitialDirection * new Vector2(doorSpeed, doorSpeed);
        }
    }

    public void respawn() {
        spriteRenderer.enabled = true;
        col.enabled = true;
        door.transform.position = initialDoorPos;
        doorOpen = false;
    }

    private void stopDoor() {
        doorRig2D.linearVelocity = Vector2.zero;
        doorOpen = true;
    }

}
