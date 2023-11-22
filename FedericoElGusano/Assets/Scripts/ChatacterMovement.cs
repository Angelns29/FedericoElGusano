using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChatacterMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    GameManager _gameManager;
    private BoxCollider2D _collider;
    private SpriteRenderer _sr;
    public float jumpForce = 10f;
    public float velocidad;
    private GameObject _platform;

    void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();

        //_platform = GameObject.Find("Col*");
        _collider = gameObject.GetComponent<BoxCollider2D>();

    }
    // Update is called once per frame
    void Update()
    {
        MovimientoHorizontal();
        Salto();

    }
    void MovimientoHorizontal()
    {


        //_rb.velocity = new Vector2(velocidad, _rb.velocity.y);

    }
    void Salto()
    {
        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            Invoke(nameof(ActivateCollider), 0.5f); // Esto activará el collider después de 0.5 segundos.

        }
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //   DesactivaCollider();
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Plataforma2"&& Input.GetKeyDown(KeyCode.DownArrow))
        {
            DesactivaCollider();
        }
    }
    void ActivateCollider()
    {
        _collider.enabled = true;
    }
    void DesactivaCollider()
    {
        _collider.enabled = false;
    }
}
