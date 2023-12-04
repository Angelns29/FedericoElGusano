using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRana : Obstacle
{
    private Rigidbody2D rb2d;
    private Animator _anim;
    public GameObject tongue;
    private UIManager uiManager;
    private AudioManagerScript _audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        _anim= GetComponent<Animator>();
        uiManager = UIManager.instance;
        _audioManager = AudioManagerScript.instance;
        tongue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y + 1), Vector2.up);
        
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                tongue.SetActive(true);
                _anim.SetBool("isAbove", true);
                StartCoroutine(WaitForDeath());
                uiManager.SetGameOver();
                //StartCoroutine(Music());
                _audioManager.PlaySFX(_audioManager.gameOverTheme);

            }
        }
        Movement(rb2d);
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0;
    }
}
