using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateToggleInteraction : InteractionBase
{
    [SerializeField] GameObject OtherObj;
    public override void PerformInteraction()
    {
        //Debug.Log("Performing");
        OtherObj.SetActive(!OtherObj.activeSelf);
    }
}
