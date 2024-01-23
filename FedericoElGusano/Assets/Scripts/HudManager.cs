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
    [SerializeField] public GameObject charges;
    [Header("Score")]
    [SerializeField] public GameObject Score;

    private int armorIndex;

    public void Start()
    {
        for (int i = 0; i < armor.Length; i++)
        {
            armor[i].gameObject.SetActive(false);
        }

        federico = GameObject.FindGameObjectWithTag("Player").GetComponent<ChatacterMovement>();
        armorIndex = federico.Inventory.actualArmor;
        for (int i = 0; i < armorIndex; i++)
        {
            armor[i].gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        if (armorIndex > federico.Inventory.actualArmor)
        {
            armorIndex--;
            armor[armorIndex].gameObject.SetActive(false);
        }
    }

    public void RestoreHud()
    {
        armorIndex = federico.Inventory.inventory.armor;
        for (int i = 0; i < armorIndex; i++)
        {
            armor[i].gameObject.SetActive(true);
        }
    }
}
