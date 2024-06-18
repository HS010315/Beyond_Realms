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
        // 레이저 시작점과 끝점 설정
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + transform.forward * 2f; // 일정 거리에 발사

        CastRay(startPos, transform.forward, laserLine); // 레이저 캐스트 함수 호출
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserBeams.Clear(); // 레이저 빔 리스트 초기화

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        float maxDistance = 2f;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // 충돌 지점까지 레이저 빔 추가
            laserBeams.Add(pos);
            laserBeams.Add(hit.point);
        }
        else
        {
            // 최대 거리까지 레이저 빔 추가
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