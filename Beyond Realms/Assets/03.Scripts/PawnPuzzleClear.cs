using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPuzzleClear : MonoBehaviour
{
    public GameObject cover;
    public float coverMoveDistance = 1f;
    public float coverMoveDuration = 2f;
    public float actionDelay = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MainPawn")
        {
            StartCoroutine(OpenCover());
        }
    }

    private IEnumerator OpenCover()
    {
        yield return new WaitForSeconds(actionDelay);

        Vector3 initialPosition = cover.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(coverMoveDistance, 0, 0); // 옆으로 이동

        float elapsedTime = 0f;

        // 커버를 천천히 옆으로 이동
        while (elapsedTime < coverMoveDuration)
        {
            cover.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / coverMoveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cover.transform.position = targetPosition;
    }
}
