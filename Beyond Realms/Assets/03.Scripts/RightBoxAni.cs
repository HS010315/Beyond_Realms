using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RightBoxAni : MonoBehaviour
{
    public Animator rightBoxAni;

    public UnityEvent rightBoxOpened;

    public GameObject[] handColliders;

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
            handColliders[0].SetActive(true);
            handColliders[1].SetActive(true);
        }
        if (is5x5PuzzleCleared && currentValue == 5)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 6);
            handColliders[0].SetActive(false);
            handColliders[1].SetActive(false);
        }
        if(isGearRotated && currentValue == 6)
        {
            rightBoxAni.SetInteger("SQ_RightSquare_State", 7);
            Invoke("OpenCheck", 1.5f);
        }
    }
    public void ButtonCheck(int num)
    {
        switch (num)
        {
            case 1:
                isButton1Pressed = true;
                break;
            case 2:
                isButton2Pressed = true;
                break;
            case 3:
                isButton3Pressed = true;
                break;
            case 4:
                isButton4Pressed = true;
                break;
        }
    }
    public void PuzzleClearCheck(int num)
    {
        switch(num)
        {
            case 1:
                isDialPuzzleCleared = true;
                break;
            case 2:
                is5x5PuzzleCleared = true;
                break;
        }
    }    
    public void OpenCheck()
    {
        rightBoxOpened.Invoke();
    }
}
