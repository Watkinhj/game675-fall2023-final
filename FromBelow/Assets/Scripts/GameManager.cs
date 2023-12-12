using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int keycards;

    private void Update()
    {
        keycards = GameObject.FindGameObjectsWithTag("Keycard").Length;
    }
}
