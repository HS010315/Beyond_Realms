using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireplaceUI : MonoBehaviour
{
    public GameObject uiPanelObject;
    public Text uiText;
    public float fadeDuration = 0.5f; // 페이드 인/아웃 지속 시간
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        if (uiPanelObject != null)
        {
            canvasGroup = uiPanelObject.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = uiPanelObject.AddComponent<CanvasGroup>();
            }
            canvasGroup.alpha = 0f; 
        }
    }

    // Update is called once per frame
    void Update()
    {

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
        else // 페이드 인 후에는 텍스트를 활성화합니다.
        {
            if (uiText != null)
            {
                uiText.gameObject.SetActive(true);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (uiPanelObject != null)
            {
                StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1f, fadeDuration));
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (uiPanelObject != null)
            {
                StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0f, fadeDuration));
            }
        }
    }
}