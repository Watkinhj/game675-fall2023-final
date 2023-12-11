using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text winDisplay;
    public TMP_Text scoreDisplay;
    public int keys = 0;

    // Update is called once per frame
    void Update()
    {
        keys = GameObject.FindGameObjectsWithTag("Key").Length;

        if (GameObject.FindGameObjectsWithTag("Key").Length == 0)
        {
            winDisplay.text = "You have all the keys! Get out now!";
        }
        else
        {
            winDisplay.text = "Find the keys to escape, lest your soul be consumed by oncoming torment!";
        }
    }
}
