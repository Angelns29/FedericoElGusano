using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTopo : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xPosition = transform.position.x;
        transform.position = new Vector3(xPosition - _velocity * ParallaxManager.instance.GetSpeed() * Time.deltaTime, transform.position.y, transform.position.z);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _animator.SetBool("isDanger", true);
            StartCoroutine(TopoIdle());
        }
    }
    IEnumerator TopoIdle()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("isDanger", false);
    }
}

