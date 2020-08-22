using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDisplayPrefab : MonoBehaviour
{
    public Achievement achievement;

    public void AssignMyAchievement(Achievement newAcheivement)
    {
        achievement = newAcheivement;
    }

    public void DisplayMyAchievement()
    {
        AchievementManager.instance.ShowOneAchievement(achievement);
    }

    public void StopDisplayingMyAchievement()
    {
        AchievementManager.instance.TurnOffAchievementDisplay();
    }
}
