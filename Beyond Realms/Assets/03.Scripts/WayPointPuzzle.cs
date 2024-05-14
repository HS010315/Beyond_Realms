using UnityEngine;
using System.Collections.Generic;

public class WayPointPuzzle : MonoBehaviour
{
    public Transform movingObject;
    public GameObject joyStick;

    void Update()
    {
        if(joyStick != null)
        {
            float angleZ = joyStick.transform.rotation.z * 180f;
            float angleX = joyStick.transform.rotation.x * 180f;
            if (angleZ > 15)
            {
                movingObject.Translate(Vector3.left * Time.deltaTime);
                Debug.Log("аб");
            }
            else if (angleZ < -15)
            {
                movingObject.Translate(Vector3.right * Time.deltaTime);
                Debug.Log("©Л");
            }
            if (angleX > 15)
            {
                movingObject.Translate(Vector3.forward * Time.deltaTime);
                Debug.Log("╬у");
            }
            else if (angleX < -15)
            {
                movingObject.Translate(Vector3.back * Time.deltaTime);
                Debug.Log("╣з");

            }
        }
    }
}