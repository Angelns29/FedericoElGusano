using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatacterMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    public float jumpForce = 10f;
    private float InputMovimiento;
    public float velocidad;
   


    void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoHorizontal();
        Salto();
      
       


    }
    void MovimientoHorizontal()
    {
        InputMovimiento = Input.GetAxisRaw("Horizontal");

        // Define una velocidad constante
        float velocidadX = InputMovimiento * velocidad;

        _rb.velocity = new Vector2(velocidadX, _rb.velocity.y);
        if (InputMovimiento > 0)
        {
            gameObject.transform.localScale = new Vector2(1, 1);
        }
       
    }
    void Salto()
    {
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
