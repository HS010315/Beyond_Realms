using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class GrabKey : MonoBehaviour
{
    public GameObject key; 
    public GameObject otherObject; // �Ÿ� üũ�� �ٸ� ������Ʈ
    public float activationDistance = 2.0f; // ������Ʈ�� Ȱ��ȭ�� �Ÿ�

    private XRGrabInteractable grabInteractable;
    private XRGeneralGrabTransformer generalGrabTransformer;
    private bool componentsActivated = false; // ������Ʈ�� Ȱ��ȭ�Ǿ����� ���θ� ����

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