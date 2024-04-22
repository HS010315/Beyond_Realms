using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderValue : MonoBehaviour
{
    public Material title3D;
    private float duration = 2f; 

    // Start is called before the first frame update
        void Start()
        {
            title3D.SetFloat("Noise_Value", 0);
        }

    // Update is called once per frame
    void Update()
    {
        float noiseValue = Mathf.Clamp01(Time.time / duration);
        title3D.SetFloat("Noise_Value", noiseValue);
    }
}