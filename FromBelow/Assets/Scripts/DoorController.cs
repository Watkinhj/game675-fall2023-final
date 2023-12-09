using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Open the door once the player enters
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered Door");
            anim.SetTrigger("Player Enters");

            anim.ResetTrigger("Player Leaves");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Close the door once the player leaves the trigger
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Player Leaves");

            anim.ResetTrigger("Player Enters");
        }
    }
}
