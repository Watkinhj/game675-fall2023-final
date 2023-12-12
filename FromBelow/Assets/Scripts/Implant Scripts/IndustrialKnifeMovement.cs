using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialKnifeMovement : PlayerController
{
    // Update is called once per frame

    void Update()
    {
        base.Update();
    }

    protected override void HandleKnifeAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            knifeObj.SetActive(true);
            Debug.Log("Knife attack!");
            //animator.SetTrigger("isAttacking");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            knifeObj.SetActive(false);
            Debug.Log("Knife attack ended.");
        }
    }
}
