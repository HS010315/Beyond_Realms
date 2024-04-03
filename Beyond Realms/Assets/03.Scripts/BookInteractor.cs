using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookInteractor : XRGrabInteractable
{
    public bool HitCollider = false;
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
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