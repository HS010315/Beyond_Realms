using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public GameObject button;
    GameObject presser;
    public Transform buttonNotPressed;
    public Transform buttonPressed;
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
        isPressed = false;
        Renderer renderer = button.GetComponent<Renderer>();
        if (renderer != null)
        {
            material = new Material(renderer.material);
            renderer.material = material; // 인스턴스 할당
            material.SetColor("_Color", NormalColor); // 초기 색상 설정
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition = buttonPressed.position;
            presser = other.gameObject;
            ButtonClicekd.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser && isPressed !=true)
        {
            button.transform.localPosition = buttonNotPressed.position;
            isPressed = true;
        }
        else if(other.gameObject == presser && isPressed == true)
        {
            button.transform.localPosition = buttonNotPressed.position;
            isPressed = false;
        }
    }

    public void Update()
    {
        if(isPressed != true)
        {
            material.SetColor("_Color", NormalColor);
        }
        else
        {
            material.SetColor("_Color", PrssedColor);
        }
    }

    public void CorrectPW()
    {
        material.SetColor("_Color", CorrectColor);
        Invoke("ResetPW", 0.5f);
    }

    public void InCorrectPW()
    {
        material.SetColor("_Color", InCorrectColor);
        Invoke("ResetPW", 0.5f);
    }

    private void ResetPW()
    {
        material.SetColor("_Color", NormalColor);
    }
}
