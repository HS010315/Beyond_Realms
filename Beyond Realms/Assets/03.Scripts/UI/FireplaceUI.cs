using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirePlaceUI : MonoBehaviour
{
    public GameObject uiPanelObject;
    public Text uiText;
    public float fadeDuration = 0.5f; // 페이드 인/아웃 지속 시간
    public GameObject referenceObject; // 거리를 측정할 참조 오브젝트
    public float fadeDistanceThreshold = 2.0f; // 페이드 인을 시작할 최대 거리

    private CanvasGroup canvasGroup;
    private bool isFading = false;

    void Start()
    {
        if (uiPanelObject != null)
        {
            canvasGroup = uiPanelObject.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = uiPanelObject.AddComponent<CanvasGroup>();
            }

            // 초기에는 페이드 아웃 상태로 설정
            canvasGroup.alpha = 0f;
            uiPanelObject.SetActive(false);
        }

        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // 참조 오브젝트와의 거리 측정
        float distance = Vector3.Distance(transform.position, referenceObject.transform.position);

        if (distance <= fadeDistanceThreshold && !isFading)
        {
            // 패널과 텍스트를 페이드 인
            StartCoroutine(FadeInPanelAndText());
        }
        else if (distance > fadeDistanceThreshold && !isFading)
        {
            // 패널과 텍스트를 페이드 아웃
            StartCoroutine(FadeOutPanelAndText());
        }
    }

    IEnumerator FadeInPanelAndText()
    {
        isFading = true;
        uiPanelObject.SetActive(true);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f;

        uiText.gameObject.SetActive(true);
        isFading = false;
    }

    IEnumerator FadeOutPanelAndText()
    {
        isFading = true;

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0f;

        uiPanelObject.SetActive(false);
        uiText.gameObject.SetActive(false);
        isFading = false;
    }
}