using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject teleportTo;
    public GameObject player;
    public float teleportDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = new Vector2(teleportTo.transform.position.x + teleportDistance, teleportTo.transform.position.y);
        }
    }
}
