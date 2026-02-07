using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Joystick input; // Reference to the Joystick component

    private LevelManager levelManager;
    private Rigidbody2D rb2d;
    private bool faceRight = true;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get input from the joystick
        float movementSpeedX = speed * input.Horizontal;
        float movementSpeedY = speed * input.Vertical;

        rb2d.linearVelocity = new Vector2(movementSpeedX, movementSpeedY);

        // Flip character based on movement direction
        if (movementSpeedX < 0 && faceRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            faceRight = false;
        }
        else if (movementSpeedX > 0 && !faceRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            faceRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            levelManager.playerDied();
        }
    }
}
