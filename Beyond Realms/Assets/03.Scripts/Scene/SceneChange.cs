using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Update()
    {
        float zRotation = transform.eulerAngles.z;
        if (zRotation > 180)
        {
            zRotation -= 360;
        }

        if (zRotation <= -140)
        {
            SceneManager.LoadScene("Chapter1_Main");
        }
    }
}