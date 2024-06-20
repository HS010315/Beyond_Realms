using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirePlaceUI : MonoBehaviour
{
    public GameObject uiPanelObject;
    public Text uiText;
    public float fadeDuration = 0.5f; // ���̵� ��/�ƿ� ���� �ð�
    public GameObject referenceObject; // �Ÿ��� ������ ���� ������Ʈ
    public float fadeDistanceThreshold = 2.0f; // ���̵� ���� ������ �ִ� �Ÿ�

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

            // �ʱ⿡�� ���̵� �ƿ� ���·� ����
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
        // ���� ������Ʈ���� �Ÿ� ����
        float distance = Vector3.Distance(transform.position, referenceObject.transform.position);

        if (distance <= fadeDistanceThreshold && !isFading)
        {
            // �гΰ� �ؽ�Ʈ�� ���̵� ��
            StartCoroutine(FadeInPanelAndText());
        }
        else if (distance > fadeDistanceThreshold && !isFading)
        {
            // �гΰ� �ؽ�Ʈ�� ���̵� �ƿ�
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