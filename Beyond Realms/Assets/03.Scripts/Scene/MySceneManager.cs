using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MySceneManager : MonoBehaviour
{
    public CanvasGroup Fade_img;
    float fadeDuration = 2;
    public GameObject Loading;
    public Text Loading_text;

    public static MySceneManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static MySceneManager instance;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;


    }
    public void ChangeScene(string sceneName)
    {
        Fade_img.DOFade(1, fadeDuration)
        .OnStart(() =>
        {
            Fade_img.blocksRaycasts = true; 
        })
        .OnComplete(() =>
        {
            StartCoroutine("LoadScene", sceneName);           
        });
        MySceneManager.Instance.ChangeScene("Scene_Tutorial");
    }
    IEnumerator LoadScene(string sceneName)
    {
        Loading.SetActive(true); //로딩 화면을 띄움

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; //퍼센트 딜레이용

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true; 
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%"; 
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration)
        .OnStart(() => {
            Loading.SetActive(false);
        })
        .OnComplete(() => {
            Fade_img.blocksRaycasts = false;
        });
    }
}