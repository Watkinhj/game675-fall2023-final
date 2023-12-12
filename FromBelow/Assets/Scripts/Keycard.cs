using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public GameObject notif; // UI notif
    public KeyCode interactKey = KeyCode.E; // Define the key for interaction

    private bool isInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            ShowNotif();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            HideNotif();
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                HideNotif();
                Destroy(gameObject);
            }
        }
    }


    void ShowNotif()
    {
        if (notif != null)
        {
            notif.SetActive(true);
        }
    }

    void HideNotif()
    {
        if (notif != null)
        {
            notif.SetActive(false);
        }
    }
}
