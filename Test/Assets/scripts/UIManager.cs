using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator UIToActivateAnim;

    private void OnTriggerEnter(Collider other)
    {
        //PlayerMovement CC = player.GetComponent<PlayerMovement>();

        if (other.CompareTag("UITrigger"))
        {
            Debug.Log("Hit UI trigger.");
            UIToActivateAnim.SetTrigger("Activated");
        }
    }
}