using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueData Dialogue;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
            other.GetComponent<PlayerController>().ShowDialogue(Dialogue);
        }
    }
}
