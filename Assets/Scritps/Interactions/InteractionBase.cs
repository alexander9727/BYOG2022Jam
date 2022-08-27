using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionBase : MonoBehaviour
{
    [SerializeField] GameObject Hint;
    public abstract void PerformInteraction();
}
