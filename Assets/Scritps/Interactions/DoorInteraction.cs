using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] UnityEvent OnCollided;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController other = collision.gameObject.GetComponentInParent<PlayerController>();

        if(other != null)
        {
            if (other.HasKey)
            {
                other.HasKey = false;
                OnCollided.Invoke();
            }
        }
    }
}
