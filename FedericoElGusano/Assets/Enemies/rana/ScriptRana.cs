using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptRana : Obstacle
{
    private Rigidbody2D rb2d;
    private Animator _anim;
    public GameObject tongue;
    private UIManager uiManager;
    private AudioManagerScript _audioManager;
    private ChatacterMovement federico;
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        _anim= GetComponent<Animator>();
        uiManager = UIManager.instance;
        _audioManager = AudioManagerScript.instance;
        tongue.SetActive(false);
        federico = GameObject.FindGameObjectWithTag("Player").GetComponent<ChatacterMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y + 1), Vector2.up);
        
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log(federico);
                tongue.SetActive(true);
                _anim.SetBool("isAbove", true);
                StartCoroutine(WaitForTongue());
                    
            }
        }
        Movement(rb2d);
    }
    IEnumerator WaitForTongue()
    {
        yield return new WaitForSeconds(0.5f);
        tongue.SetActive(false);
        _anim.SetBool("isAbove", false);
    }
}
