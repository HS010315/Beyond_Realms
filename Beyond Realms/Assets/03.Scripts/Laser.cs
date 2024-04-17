using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser
{
    Vector3 pos, dir;

    GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserBeams = new List<Vector3>();
    public bool PuzzleSolved = false;


    public Laser(Vector3 pos, Vector3 dir, Material material)
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.01f;
        this.laser.endWidth = 0.01f;
        this.laser.material = material;
        this.laser.startColor = Color.red;
        this.laser.endColor = Color.red;
        this.laser.useWorldSpace = false;

        CastRay(pos, dir, laser);
    }
    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserBeams.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        float maxDistance = 2f;

        if (Physics.Raycast(ray, out hit, maxDistance, 1))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            Vector3 endPoint = ray.GetPoint(maxDistance);
            laserBeams.Add(ray.GetPoint(maxDistance));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserBeams.Count;

        foreach(Vector3 idx in laserBeams)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }


    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector3 reflectionDirection = Vector3.Reflect(direction, hitInfo.normal);

            reflectionDirection.y = 0f;

            Vector3 pos = hitInfo.point;
            Vector3 dir = reflectionDirection.normalized;

            CastRay(pos, dir, laser);
        }
        else
        {
            laserBeams.Add(hitInfo.point);
            UpdateLaser();
        }
        if(hitInfo.collider.gameObject.tag == "EndPoint" && laserBeams.Count > 6) //수정필요
        {
            Debug.Log("Success");
            PuzzleSolved = true;
        }
        /*if(hitInfo.collider.gameObject.tag == "LaserPuzzle")
        {
            Debug.Log("oh");
        }*/
    }
}
