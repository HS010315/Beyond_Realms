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

    public GameObject[] invisibleObjects;

    private bool nightVisionEnabled = false;
    private ColorGrading colorGrading;


    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out colorGrading);
        SetObjectsVisibility(!nightVisionEnabled);
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
        if (nightVisionEnabled == false)
        {
            nightVisionEnabled = !nightVisionEnabled;
            UpdateNightVisionEffect();
        }
        else
        {
            nightVisionEnabled = true;
            UpdateNightVisionEffect();
        }
    }

    void UpdateNightVisionEffect()
    {
        if (colorGrading != null && nightVisionEnabled == true)
        {
            colorGrading.enabled.value = nightVisionEnabled;
            colorGrading.colorFilter.value = nightVisionEnabled ? nightVisionColor : normalColor;

            SetObjectsVisibility(!nightVisionEnabled);
        }
    }
    void SetObjectsVisibility(bool visible)
    {
        foreach (GameObject obj in invisibleObjects)
        {
            obj.SetActive(visible);
        }
    }
}