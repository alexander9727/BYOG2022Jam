using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] float MoveSpeed = 5;
    [SerializeField] float InteractionRadius = 1;

    [Header("Camera Movement")]
    [SerializeField] Transform MainCamera;
    [SerializeField] float MovementDirectionOffset;
    [SerializeField] float CameraLerpSpeed;
    Vector3 CameraOffset;

    [Header("Dialogue")]
    [SerializeField] GameObject DialogueBox;
    [SerializeField] Image DialogueFace;
    [SerializeField] TextMeshProUGUI DialogueCharacterName;
    [SerializeField] TextMeshProUGUI DialogueCharacterText;
    [SerializeField] float CharactersPerSecond;
    [SerializeField] DialogueData SampleDialogue;
    [SerializeField] Vector3 DialougeCameraOffset;

    [Header("Health System")]
    [SerializeField] float MaxHP = 100;
    [SerializeField] Image HPFillBar;
    float HP;


    bool CanMove => !DialogueBox.activeSelf; //Add more checks

    Rigidbody2D RB2D;
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        DialogueBox.SetActive(false);
        SetHP(MaxHP);
    }

    void Update()
    {
        //TODO: Disable before build
        Testing();


        if (CanMove)
        {
            UpdatePlayerPosition();
            CheckPlayerInteraction();
        }
    }

    private void FixedUpdate()
    {
        UpdateCamera();
    }

    void CheckPlayerInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, InteractionRadius);
            foreach (var col in colliders)
            {
                InteractionBase interaction = col.GetComponent<InteractionBase>();
                if (interaction == null) continue;


                interaction.PerformInteraction();
                return;
            }
        }
    }
    void Testing()
    {
        if (Input.GetKeyDown(KeyCode.I) && !DialogueBox.activeSelf)
        {
            ShowDialogue(SampleDialogue);
        }
    }

    void UpdatePlayerPosition()
    {
        Vector2 velocity = new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };
        RB2D.velocity = velocity * MoveSpeed;
        if (velocity.sqrMagnitude > 0)
            transform.GetChild(0).up = velocity.normalized;
        //CameraOffset = RB2D.velocity.normalized;
    }

    void UpdateCamera()
    {
        Vector3 cameraPosition = transform.position + CameraOffset * MovementDirectionOffset;
        MainCamera.position = Vector3.Lerp(MainCamera.position, cameraPosition, CameraLerpSpeed * Time.deltaTime);
    }

    public void ShowDialogue(DialogueData startDialogue)
    {
        StartCoroutine(IterateThroughDialogue(startDialogue));
    }

    IEnumerator IterateThroughDialogue(DialogueData dialogue)
    {
        CameraOffset = DialougeCameraOffset;
        DialogueBox.SetActive(true);
        while (dialogue != null)
        {
            SetDialogue(dialogue);
            yield return StartCoroutine(PrintCharacters());
            yield return new WaitUntil(() => Input.anyKeyDown);
            dialogue = dialogue.NextDialogue;
        }
        DialogueBox.SetActive(false);
        CameraOffset = Vector3.zero;
    }

    void SetDialogue(DialogueData dialogue)
    {
        DialogueFace.sprite = dialogue.CharacterHead;
        DialogueCharacterName.text = dialogue.CharacterName;
        DialogueCharacterText.text = dialogue.Dialogue;
    }

    IEnumerator PrintCharacters()
    {
        float character = 0;
        int characterCount = DialogueCharacterText.text.Length;
        while (character < characterCount)
        {
            character += Time.unscaledDeltaTime * CharactersPerSecond;
            DialogueCharacterText.maxVisibleCharacters = Mathf.RoundToInt(character);
            yield return null;
            if (Input.anyKeyDown)
            {
                break;
            }

        }
        DialogueCharacterText.maxVisibleCharacters = characterCount;

        yield return null;
    }

    void SetHP(float newHP)
    {
        HP = newHP;
        HPFillBar.fillAmount = HP / MaxHP;
    }
    public void DecreaseHP(float amount)
    {
        SetHP(HP - amount);
    }
}
