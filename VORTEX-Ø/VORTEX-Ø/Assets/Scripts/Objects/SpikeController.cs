using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour {

	public float speed;
    public Vector2 spikeAngle;
    Rigidbody2D rig2D;
    private Vector2 initialPos;
    private Vector3 boundsSize;
    private bool turning = false;

    // Use this for initialization
    void Start () {
        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.linearVelocity = spikeAngle * new Vector2(speed, speed);
        boundsSize = GetComponent<PolygonCollider2D>().bounds.size;
        initialPos = this.transform.position;

    }
	
	void Update () {
        if (turning) return;
        if (spikeAngle.x == 1) {
            if (this.transform.position.x >= initialPos.x) {
                changeDir();
            }
            else if (this.transform.position.x <= initialPos.x - boundsSize.x)
            {
                changeDir();
            }

        } else if (spikeAngle.x == -1) {
            if (this.transform.position.x <= initialPos.x) {
                changeDir();
            } 
            else if (this.transform.position.x >= initialPos.x + boundsSize.x)
            {
                changeDir();
            }
        } else if (spikeAngle.y == 1) {
            if (this.transform.position.y >= initialPos.y) {
                changeDir();
            } 
            else if (this.transform.position.y <= initialPos.y - boundsSize.y) {
                changeDir();
            }
        }

        else if (spikeAngle.y == -1) {
            if (this.transform.position.y <= initialPos.y) {
                changeDir();
            } else if (this.transform.position.y >= initialPos.y + boundsSize.y)
            {
                changeDir();
            }
        }
	}

    private void changeDir() {
        rig2D.linearVelocity *= -1;
        turning = true;
        StartCoroutine(doneTurning());
    }

    private IEnumerator doneTurning() {
        yield return new WaitForSeconds(1);
        turning = false;
    }
}

