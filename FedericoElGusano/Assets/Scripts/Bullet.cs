using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    private Animator animatorController;
    private float bulletSpeed = 5f;
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
    private void Update()
    {
        DirectionBullet();
    }
    IEnumerator DestroyBulletAfeterTime()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        Debug.Log("se ha desactivado la bala");
    }
    public void DirectionBullet()
    {
        Vector3 movimiento = Vector3.right * bulletSpeed * Time.deltaTime;
        transform.Translate(movimiento);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pared"))
        {
            AnimateExplotion();
            gameObject.SetActive(false);
           
        }
    }
    private void AnimateExplotion()
    {
        animatorController.SetBool("isExploted", true);
        Debug.Log("se ha activado la animacion");
        rb.velocity = Vector3.zero;
        StartCoroutine(DestroyBulletAfeterTime());
    }
}
