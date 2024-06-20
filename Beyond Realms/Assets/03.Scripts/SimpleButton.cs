using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleButton : MonoBehaviour
{
    public GameObject button;
    [SerializeField] private float threshold = 0.05f;
    [SerializeField] private float deadZone = 0.005f;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    bool isPressed;

    public UnityEvent ButtonClicekd;

    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        isPressed = false;
    }
    public void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
    }
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }
    void Pressed()
    {
        isPressed = true;
        ButtonClicekd.Invoke();
    }
}
