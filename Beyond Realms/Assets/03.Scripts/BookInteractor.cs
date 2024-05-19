using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class BookInteractor : XRGrabInteractable
{
    public bool HitCollider = false;

    private bool CanGrab = true;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (HitCollider && CanGrab)
        {
            Drop();
            CanGrab = false;

            StartCoroutine(EnableGrabAfterDelay(2f));
        }
    }

    public IEnumerator EnableGrabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        CanGrab = true;
    }
}