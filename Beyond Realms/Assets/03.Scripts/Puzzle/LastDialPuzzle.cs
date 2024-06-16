using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDialPuzzle : MonoBehaviour
{
    public Transform rotateDial;

    public float[] targetAngles = { 22.5f, 45f, 67.5f, 90f, 112.5f, 135f, 157.5f, 180f, 202.5f, 225f, 247.5f, 270f, 292.5f, 315f, 337.5f};

    [SerializeField] private float threshold = 0.05f;
    [SerializeField] private float deadZone = 0.005f;

    private Vector3 startPos;
    private ConfigurableJoint joint;

    public float rotationTime = 1.0f;

    public bool isPressed = false;
    public bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

        float randomAngle = targetAngles[Random.Range(0, targetAngles.Length)];
        Vector3 startRotation = rotateDial.localEulerAngles;
        rotateDial.localEulerAngles = new Vector3(startRotation.x, startRotation.y, randomAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1 && this.gameObject.CompareTag("UpButton"))
        {
            isPressed = true;
            StartCoroutine(UpPressed(22.5f));
        }
        if (!isPressed && GetValue() + threshold >= 1 && this.gameObject.CompareTag("DownButton"))
        {
            isPressed = true;
            StartCoroutine(DownPressed(22.5f));
        }
        if (isPressed && GetValue() - threshold <= 0 && this.gameObject.CompareTag("DownButton") ||
            isPressed && GetValue() - threshold <= 0 && this.gameObject.CompareTag("UpButton"))
        {
            Released();
        }
    }
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Released()
    {
        isPressed = false;
    }
    IEnumerator UpPressed(float targetAngle)
    {
        isRotating = true;

        Vector3 currentRotation = rotateDial.localEulerAngles;
        float startAngle = currentRotation.z;
        float endAngle = startAngle + targetAngle;
        endAngle %= 360f;

        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / rotationTime);

            float newAngle = Mathf.Lerp(startAngle, endAngle, t);
            rotateDial.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, newAngle);

            yield return null;
        }

        rotateDial.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, endAngle);

        isRotating = false;
    }
    IEnumerator DownPressed(float targetAngle)
    {
        isRotating = true;

        Vector3 currentRotation = rotateDial.localEulerAngles;
        float startAngle = currentRotation.z;
        float endAngle = startAngle - targetAngle;
        if (endAngle < 0)
        {
            endAngle += 360f;
        }
        else if (endAngle >= 360f)
        {
            endAngle %= 360f;
        }
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < rotationTime)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / rotationTime);

            float newAngle = Mathf.Lerp(startAngle, endAngle, t);
            rotateDial.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, newAngle);

            yield return null;
        }

        rotateDial.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, endAngle);

        isRotating = false;
    }
}
