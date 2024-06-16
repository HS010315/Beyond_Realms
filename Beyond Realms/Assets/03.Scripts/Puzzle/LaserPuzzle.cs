using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPuzzle : MonoBehaviour
{
    private LineRenderer laserLine;
    private List<Vector3> laserBeams = new List<Vector3>();

    void Start()
    {
        laserLine = gameObject.AddComponent<LineRenderer>();
        laserLine.startWidth = 0.01f;
        laserLine.endWidth = 0.01f;
        laserLine.startColor = Color.red;
        laserLine.endColor = Color.yellow;
    }

    void Update()
    {
        // ������ �������� ���� ����
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + transform.forward * 2f; // ���� �Ÿ��� �߻�

        CastRay(startPos, transform.forward, laserLine); // ������ ĳ��Ʈ �Լ� ȣ��
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserBeams.Clear(); // ������ �� ����Ʈ �ʱ�ȭ

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        float maxDistance = 2f;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // �浹 �������� ������ �� �߰�
            laserBeams.Add(pos);
            laserBeams.Add(hit.point);
        }
        else
        {
            // �ִ� �Ÿ����� ������ �� �߰�
            laserBeams.Add(pos);
            laserBeams.Add(ray.GetPoint(maxDistance));
        }

        UpdateLaser();
    }

    void UpdateLaser()
    {
        laserLine.positionCount = laserBeams.Count;

        for (int i = 0; i < laserBeams.Count; i++)
        {
            laserLine.SetPosition(i, laserBeams[i]);
        }
    }
}