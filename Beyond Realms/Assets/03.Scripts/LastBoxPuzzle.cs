using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBoxPuzzle : MonoBehaviour
{
    public bool rightBoxOpened = false;
    public bool leftBoxOpened = false;
    public bool isCleared = false;

    public GameObject[] handColliders;

    public Animator lBPani;

    public GameObject activatePuzzle;
    public GameObject[] animationPuzzle;
    public GameObject enigmaBox;
    void Start()
    {
        lBPani.SetInteger("SQ_Dial_State", 0);
    }
    void Update()
    {
        int currentValue = lBPani.GetInteger("SQ_Dial_State");
        if(rightBoxOpened && leftBoxOpened && currentValue == 0)
        {
            lBPani.SetInteger("SQ_Dial_State", 1);
            Invoke("ActivatePuzzle", 1f);
        }
        if(isCleared && currentValue == 1)
        {
            ClearedPuzzle();
            enigmaBox.SetActive(true);
            lBPani.SetInteger("SQ_Dial_State", 2);
        }
        if(currentValue == 2)
        {
            lBPani.SetInteger("SQ_Dial_State", 3);
        }
    }

    void ActivatePuzzle()
    {
        activatePuzzle.SetActive(true);
        foreach(var button in animationPuzzle)
        {
            button.SetActive(false);
        }
        handColliders[0].SetActive(true);
        handColliders[1].SetActive(true);
    }
    void ClearedPuzzle()
    {
        foreach (var button in animationPuzzle)
        {
            button.SetActive(true);
        }
        activatePuzzle.SetActive(false) ;
        handColliders[0].SetActive(false);
        handColliders[1].SetActive(false);
    }

    public void LeftBoxOpened()
    {
        leftBoxOpened = true;
    }
    public void RightBoxOpened()
    {
        rightBoxOpened = true;
    }
    public void PuzzleCleared()
    {
        isCleared = true;
    }
}
