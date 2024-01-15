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
    private InventoryManager federico;
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        _anim= GetComponent<Animator>();
        uiManager = UIManager.instance;
        _audioManager = AudioManagerScript.instance;
        tongue.SetActive(false);
        federico = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();

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
                if (federico.inventory.armor <= 0)
                {
                    StartCoroutine(WaitForDeath());
                    uiManager.SetGameOver();
                    GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>().inventory.armor = federico.actualArmor;
                }
                else GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>().inventory.armor--;
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
