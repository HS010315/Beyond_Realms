using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class GrabKey : MonoBehaviour
{
    public GameObject key; 
    public GameObject otherObject; // 거리 체크할 다른 오브젝트
    public float activationDistance = 2.0f; // 컴포넌트를 활성화할 거리

    private XRGrabInteractable grabInteractable;
    private XRGeneralGrabTransformer generalGrabTransformer;
    private bool componentsActivated = false; // 컴포넌트가 활성화되었는지 여부를 추적

    // Start is called before the first frame update
    void Start()
    {
        if (key != null)
        {
            grabInteractable = key.GetComponent<XRGrabInteractable>();
            generalGrabTransformer = key.GetComponent<XRGeneralGrabTransformer>();

            if (grabInteractable != null)
            {
                grabInteractable.enabled = false;
            }

            if (generalGrabTransformer != null)
            {
                generalGrabTransformer.enabled = false;
            }
        }
    }

    void Update()
    {
        if (key != null && otherObject != null)
        {
            float distance = Vector3.Distance(key.transform.position, otherObject.transform.position);

            if (distance > activationDistance && !componentsActivated)
            {
                if (grabInteractable != null)
                {
                    grabInteractable.enabled = true;
                }

                if (generalGrabTransformer != null)
                {
                    generalGrabTransformer.enabled = true;
                }

                componentsActivated = true; 
            }
        }
    }
}