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
        T
    }
    [SerializeField] TypesOfPipe PipeType;
    [SerializeField] float CorrectRotation;
    [SerializeField] GameObject CorrectIndicator;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public bool Validate(float maxOffset)
    {
        bool isValid = PipeType switch
        {
            //TypesOfPipe.Straight => Mathf.DeltaAngle(transform.eulerAngles.z, CorrectRotation) < maxOffset || 
            //Mathf.DeltaAngle(transform.eulerAngles.z, CorrectRotation - 180) < maxOffset || 
            //Mathf.DeltaAngle(transform.eulerAngles.z, CorrectRotation + 180) < maxOffset,
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
