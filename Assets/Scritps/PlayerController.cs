using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform MainCamera;
    [SerializeField] float MoveSpeed = 5;
    [SerializeField] GameObject DialogueBox;
    Rigidbody2D RB2D;
    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {
        Vector2 velocity = new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };
        RB2D.velocity = velocity * MoveSpeed;
        MainCamera.position = transform.position;
    }


}
