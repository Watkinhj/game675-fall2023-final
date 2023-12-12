using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int keycards;
    public int terminals = 0;
    public int implants = 0;

    private void Update()
    {
        keycards = GameObject.FindGameObjectsWithTag("Keycard").Length;
    }
}
