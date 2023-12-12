using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCheck : MonoBehaviour
{

    public GameManager gm;
    public GameObject player;
    public Animator playerAnim;
    public GameObject badEndPopup;
    public PlayerController playerController;
    public GameObject endingScreen;
    public Animator endingScreenAnim;

    //bad ending trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gm.implants >= 3)
            {
                StartCoroutine(TriggerBadEnding());
            }
        }
    }

    private IEnumerator TriggerBadEnding()
    {
        // Enable badEndPopup
        badEndPopup.SetActive(true);

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Play player anim
        playerController.enabled = false;
        playerAnim.SetTrigger("die"); 

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Play ending screen anim
        endingScreen.SetActive(true);
        endingScreenAnim.SetTrigger("ending");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        endingScreen.SetActive(true);
        endingScreenAnim.SetTrigger("ending");
    }
}
