using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPuzzle : MonoBehaviour
{
    private Vector3 direction;
    private Laser parentLaser;

    public void Initialize(Vector3 pos, Vector3 dir, Laser parent)
    {
        this.direction = dir;
        this.parentLaser = parent;
        transform.position = pos;
        transform.forward = dir;
    }

    void Update()
    {
        float speed = 20f * Time.deltaTime;
        transform.position += direction * speed;

        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, speed))
        {
            parentLaser.OnLaserHit(hit, direction);
            Destroy(gameObject);
        }
    }
}