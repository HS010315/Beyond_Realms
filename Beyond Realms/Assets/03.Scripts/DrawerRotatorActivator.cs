using Unity.VRTemplate;
using UnityEngine;

public class DrawerRotatorActivator : MonoBehaviour
{
    public Transform object1; 
    public Transform object2; 
    public DrawerRotator drawerRotator; 

    void Update()
    {
        if (Mathf.Abs(object1.eulerAngles.z - 180f) < 0.001f && Mathf.Abs(object2.eulerAngles.z - 180f) < 0.001f)
        {            
            if (drawerRotator != null && !drawerRotator.enabled)
            {
                drawerRotator.enabled = true;
            }
        }
    }
}