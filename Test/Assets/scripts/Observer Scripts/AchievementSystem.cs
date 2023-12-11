using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementSystem : Observer
{
    public TMP_Text AchievementDisplay;

    private void Start()
    {
        PlayerPrefs.DeleteAll();

        foreach (var poi in FindObjectsOfType<PointOfInterest>())
        {
            poi.RegisterObserver(this);
        }
    }

    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.AchievementUnlocked)
        {
            string achievementKey = "achivement-" + value;

            if (PlayerPrefs.GetInt(achievementKey) == 1)
                return;

            AchievementDisplay.text = "You collected a " + value;

            PlayerPrefs.SetInt(achievementKey, 1);
            Debug.Log("Unlocked" + value);
            // debug achievement confirm
        }
    }
}


public enum NotificationType
{
    AchievementUnlocked
}

