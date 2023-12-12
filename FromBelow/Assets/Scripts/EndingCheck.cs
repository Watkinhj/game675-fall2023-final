using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCheck : MonoBehaviour
{

    public GameManager gm;
    public GameObject player;
    public Animator playerAnim;
    public GameObject badEndPopup;
    public GameObject endingScreen;
    public GameObject endingScreenAnim;

    //bad ending trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gm.implants >= 3)
            {
                //ui popup
                //fucking kill the player
                //fade to black
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //fade to black
    }
}
