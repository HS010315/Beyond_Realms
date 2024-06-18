using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireplaceUI : MonoBehaviour
{
    public GameObject uiPanelObject;
    public Text uiText;
    public float fadeDuration = 0.5f; // ���̵� ��/�ƿ� ���� �ð�
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

        if (endAlpha == 0f) // ���̵� �ƿ� �Ŀ��� �ؽ�Ʈ�� ��Ȱ��ȭ�մϴ�.
        {
            if (uiText != null)
            {
                uiText.gameObject.SetActive(false);
            }
        }
        else // ���̵� �� �Ŀ��� �ؽ�Ʈ�� Ȱ��ȭ�մϴ�.
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