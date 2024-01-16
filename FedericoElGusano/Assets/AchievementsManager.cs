using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager instance;
    [SerializeField] private Achievements[] logros;

    private void Awake()
    {
        instance = this;
    }
    public void UnlockAchievement(Achievements.AchievemntTypes achievemntType)
    {
        Achievements achievementToUnlock = Array.Find(logros, dummyTrophy=> dummyTrophy._achievementType == achievemntType);

        if(!achievementToUnlock.isUnlocked) 
        {
            achievementToUnlock.UnlockThisAchievements();
        }
    }
}
