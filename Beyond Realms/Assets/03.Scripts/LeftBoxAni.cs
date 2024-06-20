using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeftBoxAni : MonoBehaviour
{
    public Animator leftBoxAni;
    public Event leftBoxOpened;

    public GameObject pianoPuzzle;
    public GameObject hidePiano;

    [HideInInspector]
    public bool isKeyRotated = false;
    [HideInInspector]
    public bool isBoxUp = false;
    [HideInInspector]
    public bool isPuzzle1Cleared = false;
    [HideInInspector]
    public bool isGearRotated = false;

    void Start()
    {
        leftBoxAni.SetInteger("SQ_LeftSquare_State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        int currentValue = leftBoxAni.GetInteger("SQ_LeftSquare_State");
        if(isKeyRotated && currentValue == 0)
        {
            leftBoxAni.SetInteger("SQ_LeftSquare_State", 1);
        }
        if(isBoxUp && currentValue == 1)
        {
            leftBoxAni.SetInteger("SQ_LeftSquare_State", 2);
            Invoke("SetPuzzle", 1f);
        }
        if(isPuzzle1Cleared && currentValue == 2)
        {
            leftBoxAni.SetInteger("SQ_LeftSquare_State", 3);
        }
        if(isGearRotated && currentValue == 3)
        {
            leftBoxAni.SetInteger("SQ_LeftSquare_State", 4);
        }
    }

    public void SetPuzzle()
    {
        int currentValue = leftBoxAni.GetInteger("SQ_LeftSquare_State");

        if (currentValue == 2)
        {
            pianoPuzzle.SetActive(true);
            hidePiano.SetActive(false);
        }

        if(currentValue == 3)
        {
            hidePiano.SetActive(true);
            pianoPuzzle.SetActive(false);
        }
    }
}
