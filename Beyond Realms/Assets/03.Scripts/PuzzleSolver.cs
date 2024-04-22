using UnityEngine;

public class PuzzleSolver : MonoBehaviour
{
    public Transform objectToMove; 
    public Vector3 targetPosition; 
    public float moveSpeed = 1f;
    public int Activate = 0;

    public void ActivateOn()
    {
        Debug.Log("+1");
        Activate++;
        MoveObject();
    }
    public void ActivateOff()
    {
        if(Activate > 0)
        {
            Debug.Log("-1");
            Activate--;
        }

    }
    public void MoveObject()
    {
        if (Activate > 10)
        {
            objectToMove.position = Vector3.Lerp(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}