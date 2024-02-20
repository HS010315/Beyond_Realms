using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class GrabTreshText : MonoBehaviour
{
    public XRGrabInteractable[] grabInteractables;
    public GameObject uiPanelObject;
    public Text uiText;

    private CanvasGroup canvasGroup;

    void Start()
    {
        foreach (var grabInteractable in grabInteractables)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrab);
            grabInteractable.onSelectExited.AddListener(OnRelease);
        }

        if (uiPanelObject != null)
        {
            canvasGroup = uiPanelObject.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = uiPanelObject.AddComponent<CanvasGroup>();
            }
        }

        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        if (canvasGroup != null)
        {
            uiPanelObject.SetActive(true);
            canvasGroup.alpha = 1f;

            if (uiText != null)
            {
                uiText.gameObject.SetActive(true);
            }
        }
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;

            StartCoroutine(DisablePanelAndTextAfterDelay(0.3f));
        }
    }

    IEnumerator DisablePanelAndTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        uiPanelObject.SetActive(false);

        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }
    }
}