using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class AnchorObejct : XRGrabInteractable
{
    public List<Transform> targetTransforms = new List<Transform>(); 
    private bool isInteracting = false; 
    private Transform currentTarget = null; 

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
        isInteracting = true;
    }
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        isInteracting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isInteracting)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Transform hitTransform = contact.otherCollider.transform;
                if (targetTransforms.Contains(hitTransform))
                {
                    if (currentTarget == null || currentTarget != hitTransform)
                    {
                        currentTarget = hitTransform;
                        transform.parent = currentTarget;
                        transform.localPosition = Vector3.zero;
                        transform.localRotation = Quaternion.identity;
                    }
                    break;
                }
            }
        }
    }
}