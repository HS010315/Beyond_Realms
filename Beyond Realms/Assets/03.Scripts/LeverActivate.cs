using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivate : MonoBehaviour
{
    public GameObject Lever1;
    public GameObject Lever2;
    public GameObject[] Levers;
    public GameObject openDesk1;
    public GameObject openDesk2;
    public GameObject[] upPuzzle;
    public GameObject doorOpen;
    public GameObject deskDown;
    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject lever in Levers)
        {
            float zAngle = lever.transform.eulerAngles.z;

            // z 각도가 50도 이상이면
            if (zAngle > 50f)
            {
                // z 각도를 60도로 고정시킵니다.
                lever.transform.eulerAngles = new Vector3(lever.transform.eulerAngles.x, lever.transform.eulerAngles.y, 60f);

                // 무빙 오브젝트를 움직이는 코드를 추가합니다.
                OpenDoor();
            }
        }
        float zAngle1 = Lever1.transform.eulerAngles.z;
        float zAngle2 = Lever2.transform.eulerAngles.z;

        if(zAngle1 > 50f)
        {
            Lever1.transform.eulerAngles = new Vector3(Lever1.transform.eulerAngles.x, Lever1.transform.eulerAngles.y, 60f);
            Puzzle1Up();
        }

        if(zAngle2 > 500f)
        {
            Lever2.transform.eulerAngles = new Vector3(Lever2.transform.eulerAngles.x, Lever2.transform.eulerAngles.y, 60f);
            DeskDown();
        }
    }

    void Puzzle1Up()
    {
        if (openDesk1 != null && openDesk2 != null)
        {

        }
        Invoke("Puzzle1Up2", 1f);
    }

    void Puzzle1Up2()
    {
        foreach (GameObject puzzlePiece in upPuzzle)
        {
            puzzlePiece.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }

    void DeskDown()
    {
        if (deskDown != null)
        {
            deskDown.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }
    void OpenDoor()
    {
        if (doorOpen != null)
        {
            doorOpen.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}
