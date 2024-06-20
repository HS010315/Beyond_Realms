using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RightBoxAni : MonoBehaviour
{
    public Animator rightBoxAni;

    public Event rightBoxOpened;
    [HideInInspector]
    public bool isButton1Pressed = false;
    [HideInInspector]
    public bool isButton2Pressed = false;
    [HideInInspector]
    public bool isButton3Pressed = false;
    [HideInInspector]
    public bool isButton4Pressed = false;
    [HideInInspector]
    public bool isDialPuzzleCleared = false;
    [HideInInspector]
    public bool is5x5PuzzleCleared = false;
    [HideInInspector]
    public bool isGearRotated = false;

    // Start is called before the first frame update
    void Start()
    {
        rightBoxAni.SetInteger("SQ_RightSquare_State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        int currentValue = rightBoxAni.GetInteger("SQ_RightSquare_State");

        if (isButton1Pressed && currentValue == 0)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 1);
        }
        if (isButton2Pressed && currentValue == 1)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 2);
        }
        if (isButton3Pressed && currentValue == 2)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 3);
        }
        if (isButton4Pressed && currentValue == 3)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 4);
        }
        if (isDialPuzzleCleared && currentValue == 4)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 5);
        }
        if (is5x5PuzzleCleared && currentValue == 5)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 6);
        }
        if(isGearRotated && currentValue == 6)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 7);        
        }
    }
}
