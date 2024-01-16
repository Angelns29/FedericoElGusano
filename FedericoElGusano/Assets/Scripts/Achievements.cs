using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    private Image image;

    public enum AchievemntTypes { avanzar, matar, monedas, muerte }
    [SerializeField] private AchievemntTypes achievementType;
    public AchievemntTypes _achievementType { get { return achievementType; } }
    public bool isUnlocked {  get; private set; }

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void CheckIfAchievementIsUnlocked()
    {
        if (PlayerPrefs.GetInt(achievementType.ToString())==0)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color= Color.white;
            isUnlocked = true;
        }
    }
    public void UnlockThisAchievements()
    {
        PlayerPrefs.SetInt(achievementType.ToString(), 1);
        CheckIfAchievementIsUnlocked();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
