using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class GrabTreshText : MonoBehaviour
{
    public XRGrabInteractable[] grabInteractables;
    public GameObject uiPanelObject;
    public Text uiText;
    public float fadeDuration = 0.5f; // 페이드 인/아웃 지속 시간

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
            StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1f, fadeDuration));

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
            StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0f, fadeDuration));
        }
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cg.alpha = endAlpha;

        if (endAlpha == 0f) // 페이드 아웃 후에는 텍스트를 비활성화합니다.
        {
            if (uiText != null)
            {
                uiText.gameObject.SetActive(false);
            }
        }
    }
}