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
                if (federico.Inventory.actualArmor <= 0)
                {
                    Debug.Log(federico.Inventory.actualArmor);
                    StartCoroutine(WaitForDeath());
                    uiManager.SetGameOver();
                    GameObject.FindGameObjectWithTag("Player").GetComponent<ChatacterMovement>().Inventory.actualArmor = federico.Inventory.inventory.armor;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<ChatacterMovement>().Inventory.actualArmor--;
                }
                    
            }
        }
        Movement(rb2d);
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0;
        _audioManager.StartGameOverTheme();
    }
}
