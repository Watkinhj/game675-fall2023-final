using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //Controller Variables
    public float mSpeed;
    public float rSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * mSpeed * vAxis, Space.World);
        gameObject.transform.Rotate(0, rSpeed * Time.deltaTime * hAxis, 0);
    }
}
