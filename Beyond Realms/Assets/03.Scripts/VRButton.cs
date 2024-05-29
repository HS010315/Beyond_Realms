using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : MonoBehaviour
{
    public GameObject button;
    GameObject presser;
    public Transform buttonNotPressed;
    public Transform buttonPressed;
    bool isPressed;

    public GameObject leverCover;

    public Material material;

    public Color PrssedColor = Color.green;
    public Color NormalColor = Color.white;
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
            CheckButtonState();
        }
        else
        {
            material.SetColor("_Color", PrssedColor);
            CheckButtonState();
        }
    }
    private void CheckButtonState()
    {
        string buttonName = button.name;
        if (buttonName == "Button1" || buttonName == "Button3")
        {
            if (isPressed)
            {
                leverCover.SetActive(false);
            }
        }
    }
}
