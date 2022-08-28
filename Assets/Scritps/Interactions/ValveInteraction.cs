using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ValveInteraction : InteractionBase
{
    [SerializeField] bool IsReady = false;
    [SerializeField] Transform Crank;
    [SerializeField] float SpinSpeed;
    [SerializeField] float SpinDuration;
    [SerializeField] UnityEvent FinalAction;
    [SerializeField] AudioClip CorrectSound;
    [SerializeField] AudioClip WrongSound;
    public override void PerformInteraction()
    {

        if (IsReady)
        {
            StartCoroutine(SpinAction());
            GetComponent<AudioSource>().PlayOneShot(CorrectSound);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(WrongSound);
        }
    }

    IEnumerator SpinAction()
    {
        float f = 0;
        while (f < SpinDuration)
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
