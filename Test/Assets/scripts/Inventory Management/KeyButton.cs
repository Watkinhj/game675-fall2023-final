using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyButton : MonoBehaviour
{
    public KeyCode key;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}

