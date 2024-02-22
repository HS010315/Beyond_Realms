using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInside : XRGrabInteractable
{
    public Transform originalParent;
    //private Vector3 originalLocalPosition;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        originalParent = transform.parent;
        transform.parent = null;
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
    }
}