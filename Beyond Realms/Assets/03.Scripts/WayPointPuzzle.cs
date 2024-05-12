using UnityEngine;
using System.Collections.Generic;

public class WaypointSystem : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>(); // 이동할 웨이포인트 목록
    public float movementSpeed = 3f; // 이동 속도
    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (waypoints.Count == 0)
            return;

        // 현재 웨이포인트를 향해 이동
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // 웨이포인트에 도착했을 때 다음 웨이포인트로 변경
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }
}