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
    [SerializeField] private int numType;
    [SerializeField] private AchievementTypes achievementType;

    [SerializeField] private GameObject rewardButton;
    public AchievementTypes _achievementType { get { return achievementType; } }
    public bool isUnlocked {  get; private set; }

    public bool rewardCollected= false;
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
            if (PlayerPrefs.GetInt(achievementType.ToString() + numType) == 0)
            {
                rewardButton.SetActive(true);
                imageBackgroundArchivement.color = Color.green;
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
        Shop shop = new Shop();
        string fileShop = "shop_items.data";
        shop = Persistence.Load(fileShop, shop);
        //Añadir Monedas al Personaje
        rewardCollected = true;
        Debug.Log("10 monedas");
        PlayerPrefs.SetInt(achievementType.ToString() + numType.ToString(), 1);
        imageBackgroundArchivement.color= Color.white;
        rewardButton.SetActive(false);
        shop.coins += 10;
        Persistence.Save(shop, fileShop);
    }
}
