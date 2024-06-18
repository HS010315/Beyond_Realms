using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotInteraction : MonoBehaviour
{
    public GameObject pot;
    public GameObject activePot;
    //public GameObject tablePuzzleAni;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            Destroy(pot);
            activePot.SetActive(true);
        }
    }

   //void Update()
   // {
   //     Animator animator = tablePuzzleAni.GetComponent<Animator>();
   //     if (activePot.activeSelf)
   //     {
   //         animator.SetInteger("123123", 1);
   //     }
   // }
}
