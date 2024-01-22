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
    [SerializeField] public GameObject armor;
    [Header("CoinsCounter")]
    [SerializeField] public GameObject coinsCounter;
    [Header("Charges")]
    [SerializeField] public GameObject charges;
    public void Start()
    {
        federico = GameObject.FindGameObjectWithTag("Player").GetComponent<ChatacterMovement>();
    }

    public void Update()
    {
    }
}
