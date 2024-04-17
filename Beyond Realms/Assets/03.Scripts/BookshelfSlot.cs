using UnityEngine;

public class BookshelfSlot : MonoBehaviour
{
    public PuzzleSolver puzzleSolver;

    private void OnTriggerEnter(Collider other)
    {
        BookInteractor bookInteractor = other.GetComponent<BookInteractor>();
        if (bookInteractor != null)
        {
            bookInteractor.HitCollider = true;
            bookInteractor.transform.parent = transform;
            bookInteractor.transform.localPosition = Vector3.zero;
            bookInteractor.transform.localRotation = Quaternion.identity; 
            puzzleSolved();
            bookInteractor.DropBook();
            Debug.Log("Ãæµ¹");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BookInteractor bookInteractor = other.GetComponent<BookInteractor>();
        if (bookInteractor != null)
        {
            bookInteractor.transform.parent = null;
            puzzleFailed();
        }
    }

    private void puzzleSolved()
    {
        puzzleSolver.ActivateOn();
    }

    private void puzzleFailed()
    {
        puzzleSolver.ActivateOff();
    }
}