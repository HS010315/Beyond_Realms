using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public Transform leverCovered;
    public Vector3 targetPosition;
    public float moveSpeed = 0.05f;
    public float moveDistance = 0.2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainPawn"))
        {
            if (leverCovered != null)
            {
                targetPosition = leverCovered.transform.position + new Vector3(moveDistance, 0, 0);
                StartCoroutine(MoveLeverCovered());
            }
        }
    }

    IEnumerator MoveLeverCovered()
    {
        while (leverCovered.transform.position.x < targetPosition.x)
        {
            leverCovered.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            yield return null;
        }

        leverCovered.transform.position = targetPosition;
    }
}
