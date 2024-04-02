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
            bookInteractor.transform.SetParent(transform);
            bookInteractor.transform.localPosition = Vector3.zero;
            puzzleSolved();
            bookInteractor.DropBook();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BookInteractor bookInteractor = other.GetComponent<BookInteractor>();
        if (bookInteractor != null)
        {
            bookInteractor.transform.SetParent(null);
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