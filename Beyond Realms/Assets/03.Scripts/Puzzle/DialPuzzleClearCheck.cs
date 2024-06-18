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
            bool allDialsAligned = true;

            foreach (var dial in rotateDials)
            {
                float currentAngle = NormalizeAngle(dial.transform.localEulerAngles.z);
                if (currentAngle != 0f)
                {
                    allDialsAligned = false;
                    break;
                }
            }

            if (allDialsAligned)
            {
                PuzzleClear();
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
        // 클리어 처리
        Debug.Log("Puzzle Cleared!");
    }
}