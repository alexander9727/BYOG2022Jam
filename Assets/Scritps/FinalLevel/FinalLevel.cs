using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FinalLevel : MonoBehaviour
{
    [SerializeField] List<Transform> LeftObjects;
    [SerializeField] List<Transform> RightObjects;
    [SerializeField] GameObject LeftRedLaser;
    [SerializeField] GameObject LeftGreenLaser;
    [SerializeField] GameObject RightGreenLaser;
    [SerializeField] GameObject RightRedLaser;
    [SerializeField] GameObject PurpleLaser;
    [SerializeField] UnityEvent OnDestroy;
    public static bool CanTurn;
    private void Start()
    {
        CanTurn = true;
        LeftGreenLaser.SetActive(false);
        LeftRedLaser.SetActive(false);
        RightGreenLaser.SetActive(false);
        RightRedLaser.SetActive(false);
        PurpleLaser.SetActive(false);
    }
    public void OnRotationChanged(Transform obj)
    {
        if (LeftObjects.Contains(obj))
        {
            if (LeftObjects[0].rotation != LeftObjects[1].rotation)
            {
                LeftRedLaser.SetActive(obj.rotation.eulerAngles.z == 90);
                LeftGreenLaser.SetActive(obj.rotation.eulerAngles.z != 90);
            }
            else
            {
                LeftRedLaser.SetActive(false);
                LeftGreenLaser.SetActive(false);
            }
        }
        else if (RightObjects.Contains(obj))
        {
            if (RightObjects[0].rotation != RightObjects[1].rotation)
            {
                RightRedLaser.SetActive(obj.rotation.eulerAngles.z != 90);
                RightGreenLaser.SetActive(obj.rotation.eulerAngles.z == 90);
            }
            else
            {
                RightRedLaser.SetActive(false);
                RightGreenLaser.SetActive(false);
            }
        }

        if ((LeftRedLaser.activeSelf && RightRedLaser.activeSelf) || (LeftGreenLaser.activeSelf && RightGreenLaser.activeSelf))
        {
            PurpleLaser.SetActive(true);
            CanTurn = false;
            Invoke(nameof(DelayDestroy), 1);
        }
    }

    void DelayDestroy()
    {
        FindObjectOfType<PlayerController>().ShakeCamera();
        OnDestroy.Invoke();
        LeftGreenLaser.SetActive(false);
        LeftRedLaser.SetActive(false);
        RightGreenLaser.SetActive(false);
        RightRedLaser.SetActive(false);
        PurpleLaser.SetActive(false);
    }
}
