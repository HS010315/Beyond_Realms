using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("IronBall"))
        {
            Destroy(collision.gameObject);
            animator.SetInteger("Ani_Table_SteelBall_State", 1);
        }
    }

}
