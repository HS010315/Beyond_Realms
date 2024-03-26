using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class NightVisionController : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Q;
    public PostProcessVolume postProcessVolume;
    public Color normalColor;
    public Color nightVisionColor = Color.green;

    private bool nightVisionEnabled = false;
    private ColorGrading colorGrading;

    private GameObject[] nightVisionObjects;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out colorGrading);

        nightVisionObjects = GameObject.FindGameObjectsWithTag("NightVisionObject");

        UpdateNightVisionEffect();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            nightVisionEnabled = !nightVisionEnabled;

            UpdateNightVisionEffect();
        }
    }

    void UpdateNightVisionEffect()
    {
        foreach (GameObject obj in nightVisionObjects)
        {
            obj.SetActive(nightVisionEnabled);
        }

        if (colorGrading != null)
        {
            colorGrading.enabled.value = nightVisionEnabled;
            colorGrading.colorFilter.value = nightVisionEnabled ? nightVisionColor : normalColor;
        }
    }
}