using UnityEngine;

public class KeyAni : MonoBehaviour
{
    public KeyInteraction keyInteraction;
    private Animator animator;
    public GameObject keyObject;

    void Start()
    {
        animator = GetComponent<Animator>();
        keyInteraction.setAnimationState = SetDoorAnimationState;
    }

    void SetDoorAnimationState()
    {
        if (animator != null)
        {
            animator.SetInteger("TutorialDoorState", 1);
            animator.SetInteger("Ani_Key_State", 1);
            keyObject.SetActive(false);
        }
    }
}