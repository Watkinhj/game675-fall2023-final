using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    public GameObject popup1; // UI popup
    public GameObject notif; // UI notif
    public GameObject popup2; // UI notif
    public GameObject popup3; // UI notif
    public GameObject popupY; // UI notif
    public GameObject popupN; // UI notif
    public GameManager gm;
    public GameObject redDoor;
    public KeyCode interactKey = KeyCode.E; // Define the key for interaction
    public KeyCode closeKey = KeyCode.C; // Define the key to close the popup
    public KeyCode YesKey = KeyCode.Y; // Define the key to say yes
    public KeyCode NoKey = KeyCode.N; // Define the key to say yes

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
            HidePopup();
            HidePopup2();
            HidePopup3();
            HidePopupY();
            HidePopupN();
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                HideNotif();
                if (gm.keycards == 0)
                {
                    ShowPopup3();
                }
                else if (gm.keycards == 0 && gm.terminals >= 3)
                {
                    ShowPopup3();
                }
                else if (gm.terminals >= 3)
                {
                    ShowPopup2();
                }
                else
                {
                    ShowPopup();
                }
            }
            else if (Input.GetKeyDown(closeKey))
            {
                HidePopup();
                HidePopup2();
                HidePopup3();
                HidePopupY();
                HidePopupN();
            }
            else if (Input.GetKeyDown(YesKey))
            {
                HidePopup3();
                ShowPopupY();
                Destroy(redDoor);
            }
            if (Input.GetKeyDown(NoKey))
            {
                HidePopup3();
                ShowPopupN();
            }
        }
    }



//All the stupid functions
void ShowPopup()
    {
        if (popup1 != null)
        {
            popup1.SetActive(true);
        }
    }

    void HidePopup()
    {
        if (popup1 != null)
        {
            popup1.SetActive(false);
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
    void ShowPopup2()
    {
        if (popup2 != null)
        {
            popup2.SetActive(true);
        }
    }

    void HidePopup2()
    {
        if (popup2 != null)
        {
            popup2.SetActive(false);
        }
    }

    void ShowPopup3()
    {
        if (popup3 != null)
        {
            popup3.SetActive(true);
        }
    }

    void HidePopup3()
    {
        if (popup3 != null)
        {
            popup3.SetActive(false);
        }
    }
    void ShowPopupY()
    {
        if (popupY != null)
        {
            popupY.SetActive(true);
        }
    }

    void HidePopupY()
    {
        if (popupY != null)
        {
            popupY.SetActive(false);
        }
    }

    void ShowPopupN()
    {
        if (popupN != null)
        {
            popupN.SetActive(true);
        }
    }

    void HidePopupN()
    {
        if (popupN != null)
        {
            popupN.SetActive(false);
        }
    }
}
