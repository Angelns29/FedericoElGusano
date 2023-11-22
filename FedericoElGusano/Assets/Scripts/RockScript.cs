using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RockScript : Obstacle
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(rb2d);
    }
}
