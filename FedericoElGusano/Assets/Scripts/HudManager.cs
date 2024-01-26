using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager instance;
    private ChatacterMovement federico;
    [Header("ArmorCounter")]
    [SerializeField] public GameObject[] armor;
    [Header("CoinsCounter")]
    [SerializeField] public TMP_Text coinsCounter;
    [Header("Charges")]
    [SerializeField] public GameObject[] charges;
    [Header("Score")]
    [SerializeField] public GameObject Score;
    public bool ready;

    //Indices para moverse en array
    private int armorIndex;
    private int chargesIndex;

    //Score 
    public static int scoreCounter;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        //Ref de federico
        ready = false;
        federico = GameObject.FindGameObjectWithTag("Player").GetComponent<ChatacterMovement>();
        armorIndex = federico.Inventory.actualArmor;
        chargesIndex = federico.Inventory.actualCharge;
        coinsCounter.text = "0";
        

        for (int i = 0; i < armorIndex; i++)
        {
            armor[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < armor.Length; i++)
        {
            armor[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < charges.Length; i++)
        {
            charges[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < chargesIndex; i++)
        {
            charges[i].gameObject.SetActive(true);
        }

        
    }

    private void Update()
    {
        if (ready)
        {
            UpdateScoreHud();
        }
    }

    //Events para determinar armor y charges
    private void OnEnable()
    {
        ChatacterMovement.OnHit += UpdateArmorHud;
        ChatacterMovement.Charge += UpdateChargeHud;
        UIManager.pauseStat += setPause;


    }
    private void OnDisable()
    {
        ChatacterMovement.OnHit -= UpdateArmorHud;
        ChatacterMovement.Charge -= UpdateChargeHud;
        UIManager.pauseStat += setPause;
    }

    public void UpdateArmorHud()
    {
        armorIndex--;
        armor[armorIndex].gameObject.SetActive(false);
    }
    public void setPause(bool pause)
    {
        ready = pause;
    }
    public void UpdateScoreHud()
    {
        scoreCounter += 1;
        Score.GetComponent<TextMeshProUGUI>().text = scoreCounter.ToString();
    }

    public void UpdateChargeHud()
    {
        chargesIndex--;
        charges[chargesIndex].gameObject.SetActive(false);
    }

    public void RestoreHud()
    {
        armorIndex = federico.Inventory.inventory.armor;
        chargesIndex = federico.Inventory.inventory.charge;
        Debug.Log(armorIndex);
        for (int i = 0; i < armorIndex; i++)
        {
            armor[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < chargesIndex; i++)
        {
            charges[i].gameObject.SetActive(true);
        }
        scoreCounter = 0;
    }
    public void UpdateCoins(float amount)
    {
        coinsCounter.text = amount.ToString();
    }
    public void RestartCoins()
    {
        coinsCounter.text = "0";
    }
}
