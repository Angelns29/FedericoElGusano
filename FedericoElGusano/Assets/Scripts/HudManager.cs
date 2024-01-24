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
    private ChatacterMovement federico;
    [Header("ArmorCounter")]
    [SerializeField] public GameObject[] armor;
    [Header("CoinsCounter")]
    [SerializeField] public GameObject coinsCounter;
    [Header("Charges")]
    [SerializeField] public GameObject[] charges;
    [Header("Score")]
    [SerializeField] public GameObject Score;

    private int armorIndex;
    private int chargesIndex;

    public void Awake()
    {
        federico = GameObject.FindGameObjectWithTag("Player").GetComponent<ChatacterMovement>();
        armorIndex = federico.Inventory.actualArmor;
        chargesIndex = federico.Inventory.actualCharge;
        
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
    private void OnEnable()
    {
        ChatacterMovement.OnHit += UpdateArmorHud;
        ChatacterMovement.Charge += UpdateChargeHud;
    }
    private void OnDisable()
    {
        ChatacterMovement.OnHit -= UpdateArmorHud;
        ChatacterMovement.Charge -= UpdateChargeHud;

    }

    public void UpdateArmorHud()
    {
        armorIndex--;
        armor[armorIndex].gameObject.SetActive(false);
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
    }
}
