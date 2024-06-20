using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeftBoxAni : MonoBehaviour
{
    public Animator leftBoxAni;
    public UnityEvent leftBoxOpened;
    public Transform keyRotate;
    private float targetRotate = 90f;

    public GameObject[] handColliders;

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
        float currentRotationY = keyRotate.localEulerAngles.y;
        if (isKeyRotated && currentValue == 0)
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
            Invoke("OpenCheck", 1.5f);
        }
        if (currentRotationY >= 85f)
        {
            keyRotate.localEulerAngles = new Vector3(keyRotate.localEulerAngles.x, 90f, keyRotate.localEulerAngles.z);
            KeyRotate();
        }
    }
    public void KeyRotate()
    {
        isKeyRotated = true;
    }
    public void BoxUp()
    {
        isBoxUp = true;
    }
    public void PuzzleCheck()
    {
        isPuzzle1Cleared = true;
    }
    public void OpenCheck()
    {
        leftBoxOpened.Invoke();
    }
    public void SetPuzzle()
    {
        int currentValue = leftBoxAni.GetInteger("SQ_LeftSquare_State");

        if (currentValue == 2)
        {
            pianoPuzzle.SetActive(true);
            hidePiano.SetActive(false);
            handColliders[0].SetActive(true);
            handColliders[1].SetActive(true);
        }

        if(currentValue == 3)
        {
            hidePiano.SetActive(true);
            pianoPuzzle.SetActive(false);
            handColliders[0].SetActive(false);
            handColliders[1].SetActive(false);
        }
    }
}
