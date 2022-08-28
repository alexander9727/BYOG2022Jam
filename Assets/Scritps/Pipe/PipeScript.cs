using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public enum TypesOfPipe
    {
        Start,
        End,
        Straight,
        Turn,
        Cross,
        T
    }
    [SerializeField] TypesOfPipe PipeType;
    [SerializeField] float CorrectRotation;
    [SerializeField] GameObject CorrectIndicator;
    [SerializeField] bool CanRotate;
    [SerializeField] bool IsRelevantToPuzzle;
    private void Start()
    {
        CorrectRotation = transform.rotation.eulerAngles.z;
        if (CanRotate)
        {
            GetComponent<Rigidbody2D>().centerOfMass = Vector2.zero;
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
        else
            GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    public bool Validate(float maxOffset)
    {
        bool isValid = !CanRotate || !IsRelevantToPuzzle ? true : PipeType switch
        {
            TypesOfPipe.Straight => Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation)) < maxOffset ||
            Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation - 180)) < maxOffset ||
            Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation + 180)) < maxOffset,

            TypesOfPipe.Cross => Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation)) < maxOffset ||
            Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation - 90)) < maxOffset ||
            Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation + 90)) < maxOffset ||
            Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation + 180)) < maxOffset,

            _ => Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, CorrectRotation)) < maxOffset
        };
        UpdateDisplayIndicator(isValid);
        return isValid;
    }

    public void UpdateDisplayIndicator(bool isValid)
    {
        CorrectIndicator.SetActive(isValid);
    }
}
