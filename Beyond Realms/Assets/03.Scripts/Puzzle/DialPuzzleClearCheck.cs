using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPuzzleClearCheck : MonoBehaviour
{
    public GameObject[] rotateDials;

    public bool isStart = false;

    void Update()
    {
        if(isStart)
        {
            foreach(var dial in rotateDials)
            {
                float currentAngle = dial.transform.localEulerAngles.z;
                if (Mathf.Approximately(currentAngle, 0f))
                {
                    PuzzleClear();
                }
            }
        }
    }

    public void PuzzleStart()
    {
        isStart = true;
    }
    public void PuzzleClear()
    {
        //애니메이션 실행 함수
    }
}
