using UnityEngine;

public class KeyAni : MonoBehaviour
{
    public KeyInteraction keyInteraction;

    void Start()
    {
        keyInteraction.setAnimationState = SetDoorAnimationState;
    }

    void SetDoorAnimationState(Animator animator)
    {
        animator.SetInteger("TutorialDoorState", 1);   
    }
}
