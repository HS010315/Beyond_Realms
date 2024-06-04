using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWordPuzzle : MonoBehaviour
{
    public string password = "1324";
    private string userClicked = "";

    public GameObject leverCover;

    private void Start()
    {
        userClicked = "";
    }
    public void PasswordClicked(string number)
    {
        userClicked += number;
        if(userClicked.Length == 4)
        {
            if(userClicked == password)
            {
                VRButton.instance.CorrectPW();
            }
            else
            {
                VRButton.instance.InCorrectPW();
                userClicked = "";
            }
        }
    }
}
