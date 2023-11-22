using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] private Transform _paralaxPivot;
    [SerializeField] private float _speed = 1f;

    public static ParallaxManager instance;

    public Transform GetParalaxPivot() => _paralaxPivot;
    public float GetSpeed() => _speed;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            //_speed += 0.1f;
        }
    } 
   
}
