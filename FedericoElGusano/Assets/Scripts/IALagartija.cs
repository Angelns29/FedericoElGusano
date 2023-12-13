using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IALagartija : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _transform;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(_transform.position.x-1, _transform.position.y), Vector2.left);
        hit.distance = 1.5f;
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                
                _rb.velocity = new Vector3(0, jumpForce, 0);
                StartCoroutine(JumpGravity());
                _rb.gravityScale = 1;
            }
        }
    }
    IEnumerator JumpGravity()
    {
        yield return new WaitForSeconds(0.7f);
        _rb.gravityScale = 3;
    }
}
