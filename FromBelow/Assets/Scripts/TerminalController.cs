using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    public GameManager gm;
    //public GameObject popup; // UI popup
    public GameObject notif; // UI notif
    public GameObject notifClose; // UI notif
    public GameObject redDoor; 
    public KeyCode interactKey = KeyCode.E; // Define the key for interaction
    public KeyCode closeKey = KeyCode.C; // Define the key to close the popup

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
            //HidePopup();
            HideNotifClose();
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                //if (!popup.activeSelf) // Check if popup is not active
                {
                    HideNotif();
                    //ShowPopup();
                    ShowNotifClose();
                    gm.terminals += 1;
                    Destroy(redDoor);
                    Debug.Log(gm.terminals);
                }
            }
            else if (Input.GetKeyDown(closeKey))
            {
                //HidePopup();
                HideNotifClose();
            }
        }
    }
    /*
    void ShowPopup()
    {
        if (popup != null)
        {
            popup.SetActive(true);
        }
    }

    void HidePopup()
    {
        if (popup != null)
        {
            popup.SetActive(false);
        }
    }
    */

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
    void ShowNotifClose()
    {
        if (notifClose != null)
        {
            notifClose.SetActive(true);
        }
    }

    void HideNotifClose()
    {
        if (notifClose != null)
        {
            notifClose.SetActive(false);
        }
    }
}
