using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemyController : MonoBehaviour {

    public float speed = 5f;
    public float delay = 4f;
    public float rotationSpeed = 50f;
    public Vector2 initialDirection;
    Rigidbody2D rig2D;
    private Vector2 startingPoint;
    private CircleCollider2D col;
    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start () {
        startingPoint = this.transform.position;

        col = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.linearVelocity = initialDirection * new Vector2(speed, speed);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "InvisWall" || other.gameObject.tag == "Enemy")
        {
            spriteRenderer.enabled = false;
            col.enabled = false;
            StartCoroutine(respawn());
        }
    }

    private IEnumerator respawn() {
        yield return new WaitForSeconds(delay);
        this.transform.position = startingPoint;
        spriteRenderer.enabled = true;
        col.enabled = true;
        rig2D.linearVelocity = initialDirection * new Vector2(speed, speed);
    }

}
