using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerDamage : MonoBehaviour
{
    [SerializeField] float Damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
            other.GetComponent<PlayerController>().DecreaseHP(Damage);
        }
    }
}
