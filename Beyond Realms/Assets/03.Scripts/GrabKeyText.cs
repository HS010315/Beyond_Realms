using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabKeyText : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public GameObject uiTextObject; // �̹� ������ UI Text ������Ʈ

    void Start()
    {
        // Grab Interactable�� �̺�Ʈ ������ �߰�
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        if (uiTextObject != null)
        {
            uiTextObject.SetActive(true); // UI Text Ȱ��ȭ
        }
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        if (uiTextObject != null)
        {
            uiTextObject.SetActive(false); // UI Text ��Ȱ��ȭ
        }
    }
}
