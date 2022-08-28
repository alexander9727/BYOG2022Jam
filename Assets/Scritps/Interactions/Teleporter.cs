using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform OtherTeleporter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        if (other.CompareTag(Constants.PlayerTag))
        {
            Debug.Log("Moving");
            other.GetComponentInParent<PlayerController>().transform.position = OtherTeleporter.transform.position;
        }
    }
}
