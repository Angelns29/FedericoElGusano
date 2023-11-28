using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChatacterMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private GameManager _gameManager;
    private BoxCollider2D _collider;
    private SpriteRenderer _sr;
    public float jumpForce = 10f;
    public float velocidad;
    private GameObject _platform;

    [SerializeField]private Transform _groundCheck;
    public LayerMask _groundLayer;
    public  UIManager _uiManager;

    void Awake()
    {
        _uiManager = gameObject.GetComponent<UIManager>();
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<BoxCollider2D>();

    }
    // Update is called once per frame
    void Update()
    {
        Salto();
    }
    void Salto()
    {
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
         
                _rb.velocity = new Vector3(0, 10, 0);

            //_rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            ActivateTrigger();
            Invoke(nameof(DesactivateTrigger), 0.6f); // Esto activará el collider después de 0.5 segundos
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ActivateTrigger();
            Invoke(nameof(DesactivateTrigger), 0.6f);
        }
    }
    void ActivateTrigger()
    {

        _collider.isTrigger = true;
    }
    void DesactivateTrigger()
    {
        _collider.isTrigger = false;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Enemy"))
        {
            StartCoroutine(WaitForDeath());
            _uiManager.SetGameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(WaitForDeath());
            _uiManager.SetGameOver();
        }
    }
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0;
    }
}
