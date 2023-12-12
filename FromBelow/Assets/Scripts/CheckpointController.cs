using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private Vector3 lastTeleporterPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter")) // MAKE SURE ALL TELEPORTERS HAVE THE TAG "Teleporter"
        {
            // Store the Teleporter's position upon trigger enter (if you are using triggers)
            lastTeleporterPosition = other.transform.position;
        }
    }

    private void RespawnPlayer()
    {
        // Teleport the player to the last Teleporter position
        transform.position = lastTeleporterPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RespawnPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     RespawnPlayer();
        // }
    }
}
