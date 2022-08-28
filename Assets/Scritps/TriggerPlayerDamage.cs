using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerDamage : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] bool IsConstant;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsConstant) return;
        if (other.CompareTag(Constants.PlayerTag))
        {
            other.GetComponent<PlayerController>().DecreaseHP(Damage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsConstant)
        {
            if (other.CompareTag(Constants.PlayerTag))
            {
                other.GetComponent<PlayerController>().DecreaseHP(Damage);
            }
        }
    }
}
