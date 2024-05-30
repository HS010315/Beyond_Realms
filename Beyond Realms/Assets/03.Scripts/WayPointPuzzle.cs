using UnityEngine;
using System.Collections.Generic;

public class WayPointPuzzle : MonoBehaviour
{
    public Transform movingObject;              //실질적으로 움직이는 물체
    public GameObject joyStick;                 //조작하는 조이스틱
    public List<GameObject> waypoints;
    public float speed = 1f;
    public int nowWayPointsIndex = 1;
    /*public Vector3 joystic_rot_normal; //회전 값을 볼 변수
    bool moving = false;
    List<Vector3> points_pos = new List<Vector3>();
    int count = 0;*/
    
    void Update()
    {
        /*joystic_rot_normal = transform.rotation.eulerAngles;
        if (!moving)
        {
            if (joystic_rot_normal.z < joystic_rot_normal.x)
            {
                if (joystic_rot_normal.z < 0)
                {
                    // movingObject 얘를 앞으로 움직이게

                }
                else if (joystic_rot_normal.z > 0)
                {
                    // movingObject 얘를 앞으로 움직이게
                }
            }
            else if (joystic_rot_normal.z > joystic_rot_normal.x)
            {
                if (joystic_rot_normal.x < 0)
                {
                    // movingObject 얘를 앞으로 움직이게
                }
                else if (joystic_rot_normal.x > 0)
                {
                    // movingObject 얘를 앞으로 움직이게
                }
            } 
        }
        else
        {
            for (int i = 0; i < points_pos.Count; i++)
            {
                if(Vector3.Distance(points_pos[i], movingObject.position) < 0.5)
                {
                    movingObject.position = points_pos[i];
                    moving = false;
                    break;
                }
                
            }
        }*/
        if (joyStick != null && movingObject != null)
        {
            float angleZ = joyStick.transform.rotation.z * 180f;
            float angleX = joyStick.transform.rotation.x * 180f;
            if (angleZ > 15 )
            {
                Debug.Log("좌");
                GoLeft();
            }
            else if (angleZ < -15)
            {
                Debug.Log("우");
                GoRight();
            }
            if (angleX > 15)
            {
                Debug.Log("앞");
                GoFront();
            }
            else if (angleX < -15)
            {
                Debug.Log("뒤");
                GoBack();
            }
        }
        else
        {
            return;
        }
    }

    void GoRight()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, wayPointNum, speed * Time.deltaTime);
        if (nowWayPointsIndex == 1)
        {
            nowWayPointsIndex = 2;
            transform.position = newPos;
        }
        if(nowWayPointsIndex == 2)
        {
            nowWayPointsIndex = 3;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 4)
        {
            nowWayPointsIndex = 6;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 5)
        {
            nowWayPointsIndex = 4;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 6)
        {
            nowWayPointsIndex = 7;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 8)
        {
            nowWayPointsIndex = 11;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 12)
        {
            nowWayPointsIndex = 13;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 13)
        {
            nowWayPointsIndex = 15;
            transform.position = newPos;
        }
    }
    void GoLeft()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, wayPointNum, speed * Time.deltaTime);
        if (nowWayPointsIndex == 2)
        {
            nowWayPointsIndex = 1;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 3)
        {
            nowWayPointsIndex = 2;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 4)
        {
            nowWayPointsIndex = 5;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 6)
        {
            nowWayPointsIndex = 4;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 7)
        {
            nowWayPointsIndex = 6;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 11)
        {
            nowWayPointsIndex = 8;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 13)
        {
            nowWayPointsIndex = 12;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 15)
        {
            nowWayPointsIndex = 13;
            transform.position = newPos;
        }
    }
    void GoFront()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, wayPointNum, speed * Time.deltaTime);
        if (nowWayPointsIndex == 4)
        {
            nowWayPointsIndex = 2;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 9)
        {
            nowWayPointsIndex = 6;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 7)
        {
            nowWayPointsIndex = 10;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 8)
        {
            nowWayPointsIndex = 4;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 12)
        {
            nowWayPointsIndex = 5;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 13)
        {
            nowWayPointsIndex = 14;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 15)
        {
            nowWayPointsIndex = 16;
            transform.position = newPos;
        }
    }
    void GoBack()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, wayPointNum, speed * Time.deltaTime);
        if (nowWayPointsIndex == 2)
        {
            nowWayPointsIndex = 4;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 6)
        {
            nowWayPointsIndex = 9;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 10)
        {
            nowWayPointsIndex = 7;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 5)
        {
            nowWayPointsIndex = 12;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 4)
        {
            nowWayPointsIndex = 8;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 14)
        {
            nowWayPointsIndex = 13;
            transform.position = newPos;
        }
        if (nowWayPointsIndex == 16)
        {
            nowWayPointsIndex = 15;
            transform.position = newPos;
        }
    }
}