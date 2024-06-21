using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public GameObject laserPrefab;    // 레이저 프리팹
    public GameObject[] cover;
    public GameObject[] nextLaserPuzzle;
    public float targetLocalYPosition = 0.135f;
    public GameObject Die;

    Laser laser;

    private void Start()
    {
        laser = new Laser(gameObject.transform.position, gameObject.transform.forward, laserPrefab);
    }

    void Update()
    {
        GameObject obj = GameObject.Find("Laser");
        if (GameObject.Find("Laser") != null && laser.PuzzleSolved == false)
        {
            Destroy(obj);
            laser = new Laser(gameObject.transform.position, gameObject.transform.forward, laserPrefab);
        }
        else if (GameObject.Find("Laser") != null && laser.PuzzleSolved == true)
        {
            Destroy(obj, 1f);
            Die.SetActive(false);
            Invoke("MoveObjectsOnYAxis", 1.0f);
            Invoke("NextLaserPuzzle", 2.0f);
        }
    }

    void MoveObjectsOnYAxis()
    {
        foreach (GameObject obj in cover)
        {
            if (obj != null)
            {
                Transform objTransform = obj.transform;
                Vector3 currentLocalPosition = objTransform.localPosition;
                currentLocalPosition.y = targetLocalYPosition;
                objTransform.localPosition = currentLocalPosition;
            }
        }
    }

    void NextLaserPuzzle()
    {
        foreach (GameObject obj in nextLaserPuzzle)
        {
            obj.SetActive(true);
        }
    }
}