using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager instance;
    [SerializeField] private Achievements[] logros;

    private void Awake()
    {
        instance = this;
    }
    public void UnlockAchievement(Achievements.AchievementTypes achievemntType)
    {
        Achievements achievementToUnlock = Array.Find(logros, trophy=> trophy._achievementType == achievemntType);

        if(achievementToUnlock == null )return;

        if(!achievementToUnlock.isUnlocked)  achievementToUnlock.UnlockThisAchievements();
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("FreddyTheWorm");
    }
}
