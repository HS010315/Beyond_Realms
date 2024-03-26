using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class NightVisionController : MonoBehaviour
{
    public Transform headPosition; 
    public Transform leftHand; 
    public Transform rightHand; 
    public float activationDistance = 0.05f; 

    public PostProcessVolume postProcessVolume;
    public Color normalColor;
    public Color nightVisionColor = Color.green;

    private bool nightVisionEnabled = false;
    private ColorGrading colorGrading;


    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        if (Vector3.Distance(leftHand.position, rightHand.position) < activationDistance ||
            Vector3.Distance(rightHand.position, headPosition.position) < activationDistance)
        {
            ToggleNightVision();
        }
    }

    void ToggleNightVision()
    {
        nightVisionEnabled = !nightVisionEnabled;
        UpdateNightVisionEffect();
    }

    void UpdateNightVisionEffect()
    {
        if (colorGrading != null && nightVisionEnabled == true)
        {
            colorGrading.enabled.value = nightVisionEnabled;
            colorGrading.colorFilter.value = nightVisionEnabled ? nightVisionColor : normalColor;
        }
    }
}