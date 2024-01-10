using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChatacterMovement : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    private SpriteRenderer _sr;
    private GameObject _platform;
    private AudioManagerScript _audioManager;
    public InventoryManager Inventory;

    [Header("Jump")]
    public float jumpForce;

    [Header("Bullet")]
    [SerializeField] public Transform bulletDirection;
    public Bullet _bullet;

    [Header("GroundCheck")]
    [SerializeField]private Transform _groundCheck;
    public LayerMask _groundLayer;
    private UIManager _uiManager;
    private bool _isGroundedDown;

    void Start()
    {
        _uiManager = UIManager.instance;
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<BoxCollider2D>();
        _audioManager = AudioManagerScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Salto();
        PlayerShoot();
    }
    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.velocity = new Vector3(0, jumpForce, 0);
            ActivateTrigger();
            Invoke(nameof(DesactivateTrigger), 0.6f);
            StartCoroutine(JumpGravity());
            _rb.gravityScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && IsGrounded() && _isGroundedDown==false)
        {
            if (_rb.gravityScale != 1) _rb.gravityScale = 1;
            ActivateTrigger();
            Invoke(nameof(DesactivateTrigger), 0.6f);
        }
    }
    IEnumerator JumpGravity()
    {
        yield return new WaitForSeconds(0.7f);
        _rb.gravityScale = 3;
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
    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Bullet bullet = BulletPool.Instance.GetBullet();

            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                
                bullet.gameObject.SetActive(true);

                bullet.DirectionBullet();
                //StartCoroutine(CanShoot());
            }
            else
            {
                Debug.Log("El objeto de la pool no tiene el componente Bullet.");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyMole"))
        {
            if (Inventory.actualArmor.Equals(0))
            {
                StartCoroutine(WaitForDeath());
                _uiManager.SetGameOver();
                Inventory.SaveCoins();
                Inventory.actualArmor = Inventory.inventory.armor;

            }
            else
            {
                Inventory.actualArmor--;
            }
            

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma2"))
        {
            _isGroundedDown = true;
        }
        else if (collision.gameObject.CompareTag("Plataforma"))
        {
            Inventory.inventory.coins++;
            Debug.Log(Inventory.inventory.coins);
            _isGroundedDown = false;
        }
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyMole"))
        {
            if (Inventory.actualArmor.Equals(0))
            {
                StartCoroutine(WaitForDeath());
                _uiManager.SetGameOver();
                Inventory.SaveCoins();
                Inventory.actualArmor = Inventory.inventory.armor;
                //_audioManager.StopMusic();

            }
            else
            {
                Inventory.actualArmor--;
                Debug.Log(Inventory.actualArmor);
            }
            

        }
    }
    
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0;
        _audioManager.StopMusic();
    }
}
