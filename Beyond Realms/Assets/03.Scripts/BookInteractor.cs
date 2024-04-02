using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookInteractor : XRGrabInteractable
{
    public bool HitCollider = false;
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
        if (HitCollider == true)
        {
            base.Drop();
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

    }

    public void DropBook()
    {
        base.Drop();
    }
}