using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}