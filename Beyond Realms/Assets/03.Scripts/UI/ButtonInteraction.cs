using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonInteraction : MonoBehaviour
{
    public string SceneName;

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(SceneName);
    }
}
