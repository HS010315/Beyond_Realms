using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPuzzleClearCheck : MonoBehaviour
{
    public GameObject[] rotateDials;
    public bool isStart = false;

    void Update()
    {
        if (isStart)
        {
            foreach (var dial in rotateDials)
            {
                float currentAngle = NormalizeAngle(dial.transform.localEulerAngles.z);
                if (Mathf.Approximately(currentAngle, 0f) || Mathf.Approximately(currentAngle, 360f))
                {
                    PuzzleClear();
                }
            }
        }
    }

    private float NormalizeAngle(float angle)
    {
        angle = angle % 360f;
        if (angle < 0)
        {
            angle += 360f;
        }
        return angle;
    }

    public void PuzzleStart()
    {
        isStart = true;
    }

    public void PuzzleClear()
    {
        // 애니메이션 실행 함수
        Debug.Log("Puzzle Cleared!");
    }
}