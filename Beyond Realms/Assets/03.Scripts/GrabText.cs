using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabText : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public GameObject uiTextObject; // 이미 설정된 UI Text 오브젝트

    void Start()
    {
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrab);
            grabInteractable.onSelectExited.AddListener(OnRelease);
        }
    }

        void OnGrab(XRBaseInteractor interactor)
        {
            if (uiTextObject != null)
            {
                uiTextObject.SetActive(true); // UI Text 활성화
            }
        }

        void OnRelease(XRBaseInteractor interactor)
        {
            if (uiTextObject != null)
            {
                uiTextObject.SetActive(false); // UI Text 비활성화
            }
        }
    
}