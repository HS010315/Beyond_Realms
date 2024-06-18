using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class GrabKey : MonoBehaviour
{
    public GameObject key;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            XRGrabInteractable grabInteractable = key.GetComponent<XRGrabInteractable>();
            XRGeneralGrabTransformer generalGrabTransformer = key.GetComponent<XRGeneralGrabTransformer>();

            if (grabInteractable != null && !grabInteractable.enabled)
            {
                grabInteractable.enabled = true;
            }

            if (generalGrabTransformer != null && !generalGrabTransformer.enabled)
            {
                generalGrabTransformer.enabled = true;
            }
        }
    }
}