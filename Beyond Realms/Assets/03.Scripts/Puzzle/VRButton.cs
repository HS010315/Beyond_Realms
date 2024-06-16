using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public GameObject button;
    [SerializeField] private float threshold = 0.05f;
    [SerializeField] private float deadZone = 0.005f;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    bool isPressed;

    public static VRButton instance;

    public int passwordNumber = 1;
    public UnityEvent ButtonClicekd;

    public Material material;

    public Color PrssedColor = Color.blue;
    public Color NormalColor = Color.white;
    public Color CorrectColor = Color.green;
    public Color InCorrectColor = Color.red;

    private void Awake()
    {
        if(VRButton.instance == null)
        {
            VRButton.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        isPressed = false;
        Renderer renderer = button.GetComponent<Renderer>();
        if (renderer != null)
        {
            material = new Material(renderer.material);
            renderer.material = material; // 인스턴스 할당
            material.SetColor("_BaseColor", NormalColor); // 초기 색상 설정
        }
    }
    public void Update()
    {
        if(!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
            material.SetColor("_BaseColor", PrssedColor);
            Debug.Log("눌림");
        }
        if(isPressed && GetValue() - threshold <= 0)
        {
            Released();
            material.SetColor("_BaseColor", NormalColor);
            Debug.Log("뗐음");
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        ButtonClicekd.Invoke();
    }

    private void Released()
    {
        isPressed = false;
    }

    public void CorrectPW()
    {
        material.SetColor("_BaseColor", CorrectColor);
        Invoke("ResetPW", 0.5f);
    }

    public void InCorrectPW()
    {
        material.SetColor("_BaseColor", InCorrectColor);
        Invoke("ResetPW", 0.5f);
    }

    private void ResetPW()
    {
        material.SetColor("_BaseColor", NormalColor);
    }
}
