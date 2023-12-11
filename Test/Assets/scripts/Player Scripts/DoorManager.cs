using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            if (gm.keys <= 0)
            {
                Destroy(other.gameObject);
            }
            else
                Debug.Log("Hit Door Trigger");
        }
    }
}
