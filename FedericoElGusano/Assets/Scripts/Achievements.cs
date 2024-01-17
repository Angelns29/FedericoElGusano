using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
   [SerializeField] private Image image;
    private Image imageBackgroundArchivement;
    [SerializeField] private Slider slider;
    [SerializeField] private int archivementCount;
    public enum AchievementTypes { avanzar, matar, monedas, muerte }
    [SerializeField] private AchievementTypes achievementType;
    public AchievementTypes _achievementType { get { return achievementType; } }
    public bool isUnlocked {  get; private set; }
    private bool rewardCollected = false;
    public GameObject rewardButton;
    private void Awake()
    {
        imageBackgroundArchivement = GetComponent<Image>();
    }
    private void Start()
    {
        CheckIfAchievementIsUnlocked();
        ChangeSlider();
    }
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt(achievementType.ToString()) == archivementCount) UnlockThisAchievements();
    }
    public void CheckIfAchievementIsUnlocked()
    {
        if (PlayerPrefs.GetInt(achievementType.ToString())>=archivementCount)
        {
            image.color = Color.white;
            isUnlocked = true;
            if (!rewardCollected )
            {
                imageBackgroundArchivement.color = Color.green;
                rewardButton.SetActive(true);
            }
        }
        else
        {
            image.color = new Color(0.14f, 0.14f, 0.14f, 255);  
        }
    }
    public void UnlockThisAchievements()
    {
        PlayerPrefs.SetInt(achievementType.ToString(), archivementCount);
        Start();
    }
    public void ChangeSlider()
    {
        float archivalue = (float)PlayerPrefs.GetInt(achievementType.ToString()) / archivementCount;
        slider.value= archivalue;
    }
    public void GetReward()
    {
        //Añadir Monedas al Personaje
        rewardCollected = true;
        rewardButton.SetActive(false);
        imageBackgroundArchivement.color = Color.white;
    }
}
