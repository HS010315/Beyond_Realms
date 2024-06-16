using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class PassWordPuzzle : MonoBehaviour
{
    public string password = "1324";
    private string userClicked = "";
    public VRButton[] vrButtons;

    public GameObject[] pokeColliders;
    public GameObject lens;
    public GameObject panel;
    public GameObject lastLever;

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
                lens.SetActive(false);
                panel.SetActive(false);
                lastLever.SetActive(true);
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
