using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light startLight; // ������ �� �����ִ� ����
    public List<Light> firstLights; // ù ���� ����
    public List<Light> secondLights; // �� ��° ���� ����

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

    private IEnumerator StartFadeOutLight(Light light) // ���� �� ����Ʈ �� �Լ�
    {
        isStart = false;
        float startIntensity = light.intensity;
        float elapsedTime = 0.0f;

        while (elapsedTime < lightFadeOutTime) // �� �� �ȿ� ������ ���ϴ°���
        {
            elapsedTime += Time.deltaTime;
            light.intensity = Mathf.Lerp(startIntensity, 0, elapsedTime / lightFadeOutTime);
            yield return null; 
        }

        light.intensity = 0;
        StartCoroutine(OnLightCoroutine(firstLights)); // ������ ���� ���� ù��° ����
        isFirstClear = true;
    }

    private IEnumerator FadeOutLight(List<Light> lightsOut) // �������� ����Ʈ�� �� �� �ִ� �Լ�
    {
        float elapsedTime = 0.0f;
        List<float> startIntensities = new List<float>(); // �� ����Ʈ�� intesity�� ������ ����Ʈ

        foreach (var light in lightsOut) // �������� ����Ʈ ����
        {
            if (light != null)
            {
                startIntensities.Add(light.intensity); // ����
            }
        }

        while (elapsedTime < lightFadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            for (int i = 0; i < lightsOut.Count; i++) // ��� ����Ʈ�� ���� ����
            {
                lightsOut[i].intensity = Mathf.Lerp(startIntensities[i], 0, elapsedTime / lightFadeOutTime);
            }
            yield return null; 
        }

        for (int i = 0; i < lightsOut.Count; i++)
        {
            lightsOut[i].intensity = 0;
        }

        if (!isSecondClear) // �� ��° ���� Ŭ���� ���� �� ���� ���� ȣ��
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
