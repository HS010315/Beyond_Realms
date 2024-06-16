using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float attractionDistance = 10.0f;  
    public float attractionForce = 10.0f;    
    public string targetTag = "Key";    

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionDistance);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                Vector3 direction = transform.position - collider.transform.position;
                direction.Normalize();
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(direction * attractionForce * Time.fixedDeltaTime, ForceMode.Acceleration);
                }
            }
        }
    }
}
