using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light startLight;                                    //������ �� �����ִ� ����
    public List<Light> firstLights;                             //ù ���� ����
    public List<Light> secondLights;                            //�� ��° ���� ����

    public bool isStart = false;
    public bool isFirstClear = false;
    public bool isSecondClear = false;

    public float lightFadeOutTime = 1.0f;
    
    private void StartFadeOutLight(Light light)          //���� �� ����Ʈ �� �Լ�
    {
        float startIntensity = light.intensity;                 //intensity�� ������ ���
        float elapsedTime = 0.0f;
        while (elapsedTime > lightFadeOutTime)                  //�� �� �ȿ� ������ ���ϴ°���
        {
            elapsedTime += Time.deltaTime;
            light.intensity = Mathf.Lerp(startIntensity, 0, elapsedTime / lightFadeOutTime);        //���۰��� ��ǥ���� ����ġ ���
        }
        light.intensity = 0;                                                                      
        light.enabled = false;
        OnLight(firstLights);        //������ ���� ���� ù��° ����
    }


    private void FadeOutLight(List<Light> lightsOut)            //�������� ����Ʈ�� �� �� �ִ� �Լ�
    {
        float elapsedTime = 0.0f;
        List<float> startIntensities = new List<float>();       //�� ����Ʈ�� intesity�� ������ ����Ʈ
        foreach (var lights in lightsOut)                  //�������� ����Ʈ ����
        {
            if (lights != null)
            {
                startIntensities.Add(lights.intensity);         //����
            }
        }
        while (elapsedTime < lightFadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            for (int i = 0; i < lightsOut.Count; i++)           //��� ����Ʈ�� ���� ����
            {
                lightsOut[i].intensity = Mathf.Lerp(startIntensities[i], 0, elapsedTime / lightFadeOutTime);
            }
        }
        for (int i = 0; i < lightsOut.Count; i++)
        {
            lightsOut[i].intensity = 0;
            lightsOut[i].enabled = false;
        }
        if (!isSecondClear)                     //�� ��° ���� Ŭ���� ���� �� ���� ���� ȣ��
        {
            OnLight(secondLights);
        }
    }

    private void OnLight(List<Light> lights)        //����Ʈ�� ���� ����Ʈ���� ���� ���� �Լ�
    {
        if (startLight.enabled == false)
        {
            foreach (var lightOn in lights)
            {
                lightOn.enabled = true;
            }
        }
    }
}
