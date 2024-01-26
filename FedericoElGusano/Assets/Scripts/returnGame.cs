using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnGame : MonoBehaviour
{
    public static returnGame instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    public void ReturnFromShop()
    {
        SceneManager.LoadScene(1);
        Destroy(gameObject);
    }
}
