using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    [SerializeField] float FinalSize;
    [SerializeField] Vector3 FinalPosition;
    [SerializeField] float MoveSpeed;
    bool ShouldMove;

    private void Update()
    {
        if (ShouldMove)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, FinalSize, MoveSpeed * Time.deltaTime);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, FinalPosition, MoveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.PlayerTag))
        {
            collision.GetComponentInParent<PlayerController>().enabled = false;
            ShouldMove = true;
        }
    }
}
