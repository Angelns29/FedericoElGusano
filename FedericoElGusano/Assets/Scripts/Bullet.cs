using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Animator animatorController;
    private float bulletSpeed = 10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    //void Start()
    //{

    //}
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
    }
    IEnumerator DestroyBulletAfeterTime()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    public void DirectionBullet()
    {
        Vector3 movimiento = Vector3.right * bulletSpeed * Time.deltaTime;
        transform.Translate(movimiento); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
