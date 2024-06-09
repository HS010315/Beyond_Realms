using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PassWordPuzzle : MonoBehaviour
{
    public string password = "1324";
    private string userClicked = "";
    public VRButton[] vrButtons;

    public GameObject[] pokeColliders;
    public GameObject leverCover;

    private void Start()
    {
        userClicked = "";
    }
    public void PasswordClicked(string number)
    {
        userClicked += number;
        Debug.Log(userClicked);
        if(userClicked.Length == 4)
        {
            if(userClicked == password)
            {
                foreach(VRButton button in vrButtons)
                {
                    button.CorrectPW();
                }
                leverCover.SetActive(false);
                pokeColliders[0].SetActive(false);
                pokeColliders[1].SetActive(false);
            }
            else
            {
                foreach (VRButton button in vrButtons)
                {
                    button.InCorrectPW();
                }
                userClicked = "";
            }
        }
    }
}
