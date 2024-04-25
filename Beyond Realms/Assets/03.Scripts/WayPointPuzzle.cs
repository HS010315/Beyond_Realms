using UnityEngine;
using System.Collections.Generic;

public class WaypointSystem : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>(); // �̵��� ��������Ʈ ���
    public float movementSpeed = 3f; // �̵� �ӵ�
    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (waypoints.Count == 0)
            return;

        // ���� ��������Ʈ�� ���� �̵�
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // ��������Ʈ�� �������� �� ���� ��������Ʈ�� ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }
}