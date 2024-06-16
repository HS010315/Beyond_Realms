using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light startLight;                                    //시작할 때 켜져있는 조명
    public List<Light> firstLights;                             //첫 퍼즐 조명
    public List<Light> secondLights;                            //두 번째 퍼즐 조명

    public bool isStart = false;
    public bool isFirstClear = false;
    public bool isSecondClear = false;

    public float lightFadeOutTime = 1.0f;
    
    private void StartFadeOutLight(Light light)          //시작 후 라이트 끌 함수
    {
        float startIntensity = light.intensity;                 //intensity는 조명의 밝기
        float elapsedTime = 0.0f;
        while (elapsedTime > lightFadeOutTime)                  //몇 초 안에 끌건지 정하는거임
        {
            elapsedTime += Time.deltaTime;
            light.intensity = Mathf.Lerp(startIntensity, 0, elapsedTime / lightFadeOutTime);        //시작값과 목표값에 도달치 계산
        }
        light.intensity = 0;                                                                      
        light.enabled = false;
        OnLight(firstLights);        //꺼지자 마자 켜질 첫번째 조명
    }


    private void FadeOutLight(List<Light> lightsOut)            //여러개의 라이트를 끌 수 있는 함수
    {
        float elapsedTime = 0.0f;
        List<float> startIntensities = new List<float>();       //각 라이트의 intesity를 저장할 리스트
        foreach (var lights in lightsOut)                  //여러개의 라이트 끄기
        {
            if (lights != null)
            {
                startIntensities.Add(lights.intensity);         //저장
            }
        }
        while (elapsedTime < lightFadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            for (int i = 0; i < lightsOut.Count; i++)           //모든 라이트를 끄는 과정
            {
                lightsOut[i].intensity = Mathf.Lerp(startIntensities[i], 0, elapsedTime / lightFadeOutTime);
            }
        }
        for (int i = 0; i < lightsOut.Count; i++)
        {
            lightsOut[i].intensity = 0;
            lightsOut[i].enabled = false;
        }
        if (!isSecondClear)                     //두 번째 퍼즐 클리어 하지 못 했을 때만 호출
        {
            OnLight(secondLights);
        }
    }

    private void OnLight(List<Light> lights)        //리스트를 가진 라이트들을 끄기 위한 함수
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
