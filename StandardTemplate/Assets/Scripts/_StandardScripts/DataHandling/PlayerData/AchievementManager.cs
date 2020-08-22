using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    #region Singleton

    public static AchievementManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion


    public Animator achievementPopUp;
    public Text achievementPopUpValue;
    public Text achievementPopUpName;
    public Text achievementPopUpDescription;
    public Image achievementPopUpImage;

    public GameObject achievementBlockPrefab;
    public Transform achievementDisplayParent;


    public Achievement[] achievements;

    private void Start()
    {
        InitializeAllAchievements();
    }

    public void InitializeAllAchievements()
    {
        for (int i = 0; i < PlayerProfile.instance.achievementProgress.Length; i++)
        {
            achievements[i].InitializeAchievement(PlayerProfile.instance.achievementProgress[i]);
        }
    }

    public void PopUpAchievement(Achievement achievement)
    {
        if (achievementPopUp != null)
        {
            achievementPopUp.SetTrigger("PopUp");
            achievementPopUpName.text = achievement.name;
            achievementPopUpDescription.text = achievement.description;
            achievementPopUpValue.text = achievement.achievementScore + "";
            achievementPopUpImage.sprite = achievement.unlockedImage;
            achievementPopUpImage.color = achievement.unlockedColor;
        }
        else
        {
            Debug.LogError("you tried to make an achievement popup but there is no popup object");
        }
    }
    
    public void DisplayAchievements()
    {
        if (achievementDisplayParent != null)
        {
            foreach (Achievement achievement in achievements)
            {
                GameObject newAchievement = Instantiate(achievementBlockPrefab, achievementDisplayParent);
                Image achievementSprite = newAchievement.GetComponentsInChildren<Image>()[1]; //this will be the second one because the first Image it will grab will be the parent panel


                Text[] acheivementTextObjects = newAchievement.GetComponentsInChildren<Text>();
                acheivementTextObjects[0].text = achievement.achievementScore + "";
                if (acheivementTextObjects.Length > 1)
                {
                    acheivementTextObjects[1].text = achievement.name;

                    if (acheivementTextObjects.Length > 2)
                    {
                        acheivementTextObjects[2].text = achievement.description;
                    }
                }
            }
        }
    }

    public void MadeAchievementProgress(string achievementName, int progress = 0)
    {
        if (achievementName != "")
        {
            Achievement achievement = Array.Find(achievements, achievementData => achievementData.name == achievementName);
            if (achievement != null && !achievement.isUnlocked)
            {
                achievement.AddProgressTowardsAchievement(progress);
            }
            else if (achievement == null)
            {
                Debug.LogError("Achievement Not Found: " + name);
            }

        }
    }
}

[Serializable]
public class Achievement
{
    public string name;
    public string description;
    public bool isUnlocked;
    public int achievementIndex;

    public Sprite lockedImage;
    public Color lockedColor;

    public Sprite unlockedImage;
    public Color unlockedColor;

    public AchievementType type;

    public int progressOrBest;
    public int achievementGoal;

    public int achievementScore;

    public void InitializeAchievement(int progress)
    {
        if (type == AchievementType.Bool)
        {
            if (progress == -1)
            {
                isUnlocked = true;
            }
            else
            {
                isUnlocked = false;
            }
        }
        else
        {
            if (progress >= achievementGoal)
            {
                isUnlocked = true;
            }
            else
            {
                isUnlocked = false;
            }
        }
    }

    public void UnlockAchievement()
    {
        PlayerProfile.instance.achievementScore += achievementScore;

        if (type == AchievementType.Bool)
        {
            PlayerProfile.instance.achievementProgress[achievementIndex] = -1;
        }
        else
        {
            PlayerProfile.instance.achievementProgress[achievementIndex] = progressOrBest;
        }

        isUnlocked = true;
        AchievementManager.instance.PopUpAchievement(this);
    }

    public void AddProgressTowardsAchievement(int progress)
    {
        if (!isUnlocked)
        {
            if (type == AchievementType.IntCumulative)
            {
                progressOrBest += progress;

                if (progressOrBest >= achievementGoal)
                {
                    progressOrBest = achievementGoal;
                    UnlockAchievement();
                }
            }
            else if (type == AchievementType.IntSingle && progress >= progressOrBest)
            {
                progressOrBest = progress;

                if (progressOrBest >= achievementGoal)
                {
                    progressOrBest = achievementGoal;
                    UnlockAchievement();
                }
            }
            else
            {
                UnlockAchievement();
            }
        }
    }
}

public enum AchievementType
{
    Bool,
    IntCumulative,
    IntSingle
}