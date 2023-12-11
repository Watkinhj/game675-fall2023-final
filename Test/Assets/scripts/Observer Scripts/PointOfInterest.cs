using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : Subject
{
    [SerializeField]
    private string poiName;

    public GameManager gm;

    public Item Item;

    public event Action OnCollected;

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
      
        
        Notify(poiName, NotificationType.AchievementUnlocked);
        Collect();
    }

    private void OnTriggerEnter(Collider other)
    {
            if (gameObject.tag == "Key")
            {
                Notify(poiName, NotificationType.AchievementUnlocked);
                Pickup();
                //gm.keys++;


                /*
                gm.healthy++;
                gm.hunger = gm.hunger + 10;
                Debug.Log("Healthy food: " + gm.healthy);
                Debug.Log("Fullness: " + gm.hunger);
                */

            }

    }
    public void Collect()
    {
        Debug.Log("Collect method called"); 
        OnCollected?.Invoke();
        SoundManager.Instance.PlayCollectSound();
    }
}
