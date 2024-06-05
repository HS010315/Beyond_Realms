using UnityEngine;
using System.Collections.Generic;

public class WayPointPuzzle : MonoBehaviour
{
    public Transform movingObject;              //실질적으로 움직이는 물체
    public GameObject joyStickX;                //X축 조작하는 조이스틱
    public GameObject joyStickZ;                //Z축 조작하는 조이스틱
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
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        if (joyStickZ != null && joyStickX != null && movingObject != null)
        {
            float angleZ = joyStickZ.transform.rotation.z * 180f;
            float angleX = joyStickX.transform.rotation.x * 180f;
            if (angleZ > 15 )
            {
                Debug.Log("좌");
                Invoke("GoLeft", 0.5f);
            }
            else if (angleZ < -15)
            {
                Debug.Log("우");
                Invoke("GoRight", 0.5f);
            }
            if (angleX > 15)
            {
                Debug.Log("앞");
                Invoke("GoFront", 0.5f);
            }
            else if (angleX < -15)
            {
                Debug.Log("뒤");
                Invoke("GoBack", 0.5f);
            }
        }
        else
        {
            return;
        }
        Vector3.MoveTowards(movingObject.transform.position, wayPointNum, speed * Time.deltaTime);
    }

    void GoRight()
    {
        //Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        switch(nowWayPointsIndex)
        {
            case 1:
                nowWayPointsIndex = 2;
                break;
            case 2:
                nowWayPointsIndex = 3;
                break;
            case 4:
                nowWayPointsIndex = 6;
                break;
            case 5:
                nowWayPointsIndex = 4;
                break;
            case 6:
                nowWayPointsIndex = 7;
                break;
            case 8:
                nowWayPointsIndex = 11;
                break;
            case 12:
                nowWayPointsIndex = 13;
                break;
            case 13:
                nowWayPointsIndex = 15;
                break;
        }
        //Vector3.MoveTowards(movingObject.transform.position, wayPointNum, speed * Time.deltaTime);
    }
    void GoLeft()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        switch (nowWayPointsIndex)
        {
            case 2:
                nowWayPointsIndex = 1;
                break;
            case 3:
                nowWayPointsIndex = 2;
                break;
            case 4:
                nowWayPointsIndex = 5;
                break;
            case 6:
                nowWayPointsIndex = 4;
                break;
            case 7:
                nowWayPointsIndex = 6;
                break;
            case 11:
                nowWayPointsIndex = 8;
                break;
            case 13:
                nowWayPointsIndex = 12;
                break;
            case 15:
                nowWayPointsIndex = 13;
                break;
        }
        Vector3.MoveTowards(movingObject.transform.position, wayPointNum, speed * Time.deltaTime);
    }
    void GoFront()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        switch(nowWayPointsIndex)
        {
            case 4:
                nowWayPointsIndex = 2;
                break;
            case 9:
                nowWayPointsIndex = 6;
                break;
            case 7:
                nowWayPointsIndex = 10;
                break;
            case 8:
                nowWayPointsIndex = 4;
                break;
            case 12:
                nowWayPointsIndex = 5;
                break;
            case 13:
                nowWayPointsIndex = 14;
                break;
            case 15:
                nowWayPointsIndex = 16;
                break;
        }
        Vector3.MoveTowards(movingObject.transform.position, wayPointNum, speed * Time.deltaTime);
    }
    void GoBack()
    {
        Vector3 wayPointNum = waypoints[nowWayPointsIndex].transform.position;
        switch(nowWayPointsIndex)
        {
            case 2:
                nowWayPointsIndex = 4;
                break;
            case 6:
                nowWayPointsIndex = 9;
                break;
            case 10:
                nowWayPointsIndex = 7;
                break;
            case 5:
                nowWayPointsIndex = 12;
                break;
            case 4:
                nowWayPointsIndex = 8;
                break;
            case 14:
                nowWayPointsIndex = 13;
                break;
            case 16:
                nowWayPointsIndex = 15;
                break;
        }
        Vector3.MoveTowards(movingObject.transform.position, wayPointNum, speed * Time.deltaTime);
    }  
}