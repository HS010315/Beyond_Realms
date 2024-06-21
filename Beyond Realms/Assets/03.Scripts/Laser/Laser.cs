using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser
{
    Vector3 pos, dir;
    GameObject laserPrefab;

    GameObject currentLaser;
    public bool PuzzleSolved = false;

    public Laser(Vector3 pos, Vector3 dir, GameObject laserPrefab)
    {
        this.pos = pos;
        this.dir = dir;
        this.laserPrefab = laserPrefab;

        FireLaser(pos, dir);
    }

    void FireLaser(Vector3 pos, Vector3 dir)
    {
        currentLaser = GameObject.Instantiate(laserPrefab, pos, Quaternion.LookRotation(dir));
        currentLaser.GetComponent<LaserPuzzle>().Initialize(pos, dir, this);
    }

    public void OnLaserHit(RaycastHit hitInfo, Vector3 direction)
    {
        if (hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector3 reflectionDirection = Vector3.Reflect(direction, hitInfo.normal);
            reflectionDirection.y = 0f;
            FireLaser(hitInfo.point, reflectionDirection.normalized);
        }
        else if (hitInfo.collider.gameObject.tag == "EndPoint")
        {
            Debug.Log("Success");
            PuzzleSolved = true;
        }
    }
}