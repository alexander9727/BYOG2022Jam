using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : InteractionBase
{
    public override void PerformInteraction()
    {
        FindObjectOfType<PlayerController>().HasKey = true;
        gameObject.SetActive(false);
    }
}
