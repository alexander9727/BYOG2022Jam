using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ValveInteraction : InteractionBase
{
    bool IsReady = false;
    [SerializeField] Transform Crank;
    [SerializeField] float SpinSpeed;
    [SerializeField] float SpinDuration;
    [SerializeField] UnityEvent FinalAction;
    public override void PerformInteraction()
    {
        if (IsReady)
        {
            //TODO: Play Crank sound
            StartCoroutine(SpinAction());
            Debug.Log("Wrong");
        }
        else
        {
            //TODO: Play wrong sound
            Debug.Log("Wrong");
        }
    }

    IEnumerator SpinAction()
    {
        float f = 0;
        while(f < SpinDuration)
        {
            f += Time.deltaTime;
            Crank.Rotate(0, 0, SpinSpeed * Time.deltaTime);
            yield return null;
        }

        FinalAction.Invoke();
    }

    public void UpdateReady(bool status)
    {
        IsReady = status;
    }
}
