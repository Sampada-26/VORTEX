using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 5f;
    public Vector2 initialDirection;
    public float rotationSpeed = 50;
    Rigidbody2D rig2D;

    void Start () {
        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        rig2D.linearVelocity = initialDirection * new Vector2(speed, speed);
    }

    void Update () {
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
