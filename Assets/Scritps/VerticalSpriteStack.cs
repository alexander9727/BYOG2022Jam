using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpriteStack : MonoBehaviour
{
    [SerializeField] float XOffset;
    [SerializeField] int OffsetCount;
    [SerializeField] float YSpace;

#if UNITY_EDITOR
    private void OnValidate()
    {
        Rearrange();
    }

    private void OnTransformChildrenChanged()
    {
        Rearrange();
    }
    private void OnTransformParentChanged()
    {
        Rearrange();
    }
#endif

    public void Rearrange()
    {
        List<SpriteRenderer> renderers = new List<SpriteRenderer>();

        Vector2 position = Vector2.zero;
        int internalCount = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            SpriteRenderer sr = transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                renderers.Add(sr);
                position.x = XOffset * (internalCount % OffsetCount);
                sr.transform.localPosition = position;
                position.y -= sr.bounds.size.y + YSpace;
                internalCount++;
            }
        }


        position.y -= YSpace;

        foreach (SpriteRenderer sr in renderers)
        {
            sr.transform.localPosition -= Vector3.up * position.y / 2;
        }
    }
}
