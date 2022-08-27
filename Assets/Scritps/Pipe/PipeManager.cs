using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PipeManager : MonoBehaviour
{
    [SerializeField] float MaxPipeDifference;
    [SerializeField] PipeScript[] AllPipes;
    [SerializeField] UnityEvent<bool> HasValidated;
    bool IsCorrect = false;
    void Start()
    {
        IsCorrect = false;
    }

    private void Update()
    {
        bool isCorrect = true;
        foreach(PipeScript pipe in AllPipes)
        {
            if (!isCorrect)
            {
                pipe.UpdateDisplayIndicator(false);
                continue;
            }
            if (!pipe.Validate(MaxPipeDifference))
            {
                isCorrect = false;
            }
        }

        if(IsCorrect != isCorrect)
        {
            IsCorrect = isCorrect;
            HasValidated.Invoke(isCorrect);
        }
    }
}
