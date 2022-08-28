using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelInteraction : InteractionBase
{
    [SerializeField] float[] Rotations = new float[] { 90, -90 };
    int Current;
    private void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * Rotations[0]);
        Current = 0;
    }
    public override void PerformInteraction()
    {
        if (FinalLevel.CanTurn)
        {
            Current = (Current + 1) % Rotations.Length;
            transform.rotation = Quaternion.Euler(Vector3.forward * Rotations[Current]);
            GetComponentInParent<FinalLevel>().OnRotationChanged(transform);
        }
    }
}
