using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatacterMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    public float jumpForce = 10f;


    void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Personaje se mueve a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _rb.velocity = new Vector2(4, 0);
            _animator.SetBool("isRunning", true);
            _sr.flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);

        }
        //Personaje se mueve a la izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _rb.velocity = new Vector2(-4, 0);
            _sr.flipX = true;
            _animator.SetBool("isRunning", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);
        }
        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
