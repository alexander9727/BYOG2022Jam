using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Dialogue")]
public class DialogueData : ScriptableObject
{
    public Sprite CharacterHead;
    public string CharacterName;
    [TextArea] public string Dialogue;
    public DialogueData NextDialogue;
}
