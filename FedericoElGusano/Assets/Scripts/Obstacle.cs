using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;

    public void Movement(Rigidbody2D rb2d)
    {
        rb2d.velocity = new Vector2(speed * -1, 0);
    }
}

