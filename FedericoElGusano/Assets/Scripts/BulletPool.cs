using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public Bullet bulletprefab;
    private int bulletsize = 5;
    private List<Bullet> bullets = new List<Bullet>();
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        InicializePool();

    }
    private void InicializePool()
    {

        for (int i = 0; i < bulletsize; i++)
        {
            Bullet bullet = Instantiate(bulletprefab);
            bullet.gameObject.SetActive(false);
            bullets.Add(bullet);
        }
    }
    public Bullet GetBullet()
    {
        foreach (Bullet bullet in bullets)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;

    }
}
