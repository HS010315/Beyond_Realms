using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotInteraction : MonoBehaviour
{
    public GameObject pot;
    public GameObject activePot;
    public GameObject AniShelf;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            Destroy(pot);
            activePot.SetActive(true);
        }
    }

   void Update()
   {
        Animator animator = AniShelf.GetComponent<Animator>();
        if (activePot.activeSelf)
        {
            animator.SetInteger("Ani_Shelf_State", 1);
        }
   }
}
