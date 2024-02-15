using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabTreshText : MonoBehaviour
{
    public XRGrabInteractable[] grabInteractables;
    public GameObject uiTextTreshObject; 


    void Start()
    {
        foreach (var grabInteractable in grabInteractables)
        {
            // Grab Interactable에 이벤트 리스너 추가
            grabInteractable.onSelectEntered.AddListener(OnGrab);
            grabInteractable.onSelectExited.AddListener(OnRelease);
        }
    }

    void OnGrab(XRBaseInteractor interactor)
        {
            if (uiTextTreshObject != null)
            {
                uiTextTreshObject.SetActive(true); // UI Text 활성화
            }

        }

        void OnRelease(XRBaseInteractor interactor)
        {
            if (uiTextTreshObject != null)
            {
                uiTextTreshObject.SetActive(false); // UI Text 비활성화
            }

        }




}