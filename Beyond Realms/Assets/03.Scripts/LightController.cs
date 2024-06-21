using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light startLight; // 시작할 때 켜져있는 조명
    public List<Light> firstLights; // 첫 퍼즐 조명
    public List<Light> secondLights; // 두 번째 퍼즐 조명

    public bool isStart;
    public bool isFirstClear = false;
    public bool isSecondClear = false;

    public float lightFadeOutTime = 1.0f;

    public void Start()
    {
        startLight.intensity = 0f;
        foreach(var lights1 in firstLights)
        {
            lights1.intensity = 0f;
        }
        foreach(var lights2 in secondLights)
        {
            lights2.intensity = 0f;
        }
        isStart = true;
    }

    public void Update()
    {
        if (startLight.intensity < 16f && isStart)
        {
            startLight.intensity += Time.deltaTime * 2;
        }
        if (startLight.intensity >= 16f && isStart)
        {
            startLight.intensity = 16f;
            StartCoroutine(StartFadeOutLight(startLight));
        }

        if (isFirstClear)
        {
            StartCoroutine(FadeOutLight(firstLights));
        }
    }

    private IEnumerator StartFadeOutLight(Light light) // 시작 후 라이트 끌 함수
    {
        isStart = false;
        float startIntensity = light.intensity;
        float elapsedTime = 0.0f;

        while (elapsedTime < lightFadeOutTime) // 몇 초 안에 끌건지 정하는거임
        {
            elapsedTime += Time.deltaTime;
            light.intensity = Mathf.Lerp(startIntensity, 0, elapsedTime / lightFadeOutTime);
            yield return null; 
        }

        light.intensity = 0;
        StartCoroutine(OnLightCoroutine(firstLights)); // 꺼지자 마자 켜질 첫번째 조명
        isFirstClear = true;
    }

    private IEnumerator FadeOutLight(List<Light> lightsOut) // 여러개의 라이트를 끌 수 있는 함수
    {
        float elapsedTime = 0.0f;
        List<float> startIntensities = new List<float>(); // 각 라이트의 intesity를 저장할 리스트

        foreach (var light in lightsOut) // 여러개의 라이트 끄기
        {
            if (light != null)
            {
                startIntensities.Add(light.intensity); // 저장
            }
        }

        while (elapsedTime < lightFadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            for (int i = 0; i < lightsOut.Count; i++) // 모든 라이트를 끄는 과정
            {
                lightsOut[i].intensity = Mathf.Lerp(startIntensities[i], 0, elapsedTime / lightFadeOutTime);
            }
            yield return null; 
        }

        for (int i = 0; i < lightsOut.Count; i++)
        {
            lightsOut[i].intensity = 0;
        }

        if (!isSecondClear) // 두 번째 퍼즐 클리어 하지 못 했을 때만 호출
        {
            StartCoroutine(OnLightCoroutine(secondLights));
        }
    }

    private IEnumerator OnLightCoroutine(List<Light> lights)
    {
        float maxIntensity = 4f; 
        float increaseSpeed = 1f; 

        foreach (var lightOn in lights)
        {
            while (lightOn.intensity < maxIntensity)
            {
                lightOn.intensity += increaseSpeed * Time.deltaTime;
                yield return null;
            }
            lightOn.intensity = maxIntensity; 
        }
    }
}
