using UnityEngine;
using System.Collections.Generic;

public class WayPointPuzzle : MonoBehaviour
{
    public Transform movingObject;              //실질적으로 움직이는 물체
    public GameObject joyStickX;                //X축 조작하는 조이스틱
    public GameObject joyStickZ;                //Z축 조작하는 조이스틱
    public List<GameObject> waypoints;
    public float speed = 1f;
    public int nowWayPointsIndex = 0;

    public bool isMoving = false;
    void Update()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        if (joyStickZ != null && joyStickX != null && movingObject != null )
        {
            float angleZ = joyStickZ.transform.rotation.z * 180f;
            float angleX = joyStickX.transform.rotation.x * 180f;
            if (angleZ > 30 && angleZ <=31 && !isMoving)
            {
                isMoving = true;
                Invoke("GoLeft", 1f);
            }
            else if (angleZ < -30 && angleZ >=-31 && !isMoving)
            {
                isMoving = true;
                Invoke("GoRight", 1f);
            }
            if (angleX > 30 && angleX <= 31 && !isMoving)
            {
                isMoving = true;
                Invoke("GoFront", 1f);
            }
            else if (angleX < -30 && angleX >= -31 && !isMoving)
            {
                isMoving = true;
                Invoke("GoBack", 1f);
            }
        }
        else
        {
            return;
        }
        movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, wayPointNum, speed * Time.deltaTime);
    }

    void GoRight()
    {
        switch(nowWayPointsIndex)
        {
            case 0:
                nowWayPointsIndex = 1;
                break;
            case 1:
                nowWayPointsIndex = 2;
                break;
            case 3:
                nowWayPointsIndex = 5;
                break;
            case 4:
                nowWayPointsIndex = 3;
                break;
            case 5:
                nowWayPointsIndex = 6;
                break;
            case 7:
                nowWayPointsIndex = 10;
                break;
            case 11:
                nowWayPointsIndex = 12;
                break;
            case 12:
                nowWayPointsIndex = 14;
                break;
        }
        isMoving = false;
    }
    void GoLeft()
    {
        switch (nowWayPointsIndex)
        {
            case 1:
                nowWayPointsIndex = 0;
                break;
            case 2:
                nowWayPointsIndex = 1;
                break;
            case 3:
                nowWayPointsIndex = 4;
                break;
            case 5:
                nowWayPointsIndex = 3;
                break;
            case 6:
                nowWayPointsIndex = 5;
                break;
            case 10:
                nowWayPointsIndex = 7;
                break;
            case 12:
                nowWayPointsIndex = 11;
                break;
            case 14:
                nowWayPointsIndex = 12;
                break;
        }
        isMoving = false;
    }
    void GoFront()
    {
        switch(nowWayPointsIndex)
        {
            case 3:
                nowWayPointsIndex = 1;
                break;
            case 8:
                nowWayPointsIndex = 5;
                break;
            case 6:
                nowWayPointsIndex = 9;
                break;
            case 7:
                nowWayPointsIndex = 3;
                break;
            case 11:
                nowWayPointsIndex = 4;
                break;
            case 12:
                nowWayPointsIndex = 13;
                break;
            case 14:
                nowWayPointsIndex = 15;
                break;
        }
        isMoving = false;
    }
    void GoBack()
    {
        switch(nowWayPointsIndex)
        {
            case 1:
                nowWayPointsIndex = 3;
                break;
            case 5:
                nowWayPointsIndex = 8;
                break;
            case 9:
                nowWayPointsIndex = 6;
                break;
            case 4:
                nowWayPointsIndex = 11;
                break;
            case 3:
                nowWayPointsIndex = 7;
                break;
            case 13:
                nowWayPointsIndex = 12;
                break;
            case 15:
                nowWayPointsIndex = 14;
                break;
        }
        isMoving = false;
    }
}