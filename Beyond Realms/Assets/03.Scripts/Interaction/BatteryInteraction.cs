using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryInteraction : MonoBehaviour
{
    public GameObject battery1;
    public GameObject battery2;
    public GameObject puzzleDisk;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Battery"))
        {
            Destroy(collision.gameObject);

            if (battery1 != null)
            {
                battery1.SetActive(true);
            }
        }
    }
    void Update()
    {
        Animator animator = puzzleDisk.GetComponent<Animator>();
        if (battery1.activeSelf)
        {
            animator.SetInteger("C3_HX_Disk_State", 1);
        }
    }
}
