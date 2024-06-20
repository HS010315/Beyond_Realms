using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxControll : MonoBehaviour
{
    public float targetY = 1.45f;
    public float lastTargetY = 1.47f;

    public UnityEvent boxUp;
    public DragInteract dragInteract;
    void Update()
    {
        float currentY = transform.localPosition.y;

        if (currentY >= targetY)
        {
            Vector3 newPosition = transform.localPosition;
            if (dragInteract != null)
            {
                dragInteract.enabled = false;
            }
            newPosition.y = lastTargetY;
            transform.localPosition = newPosition;

        }
    }
}
