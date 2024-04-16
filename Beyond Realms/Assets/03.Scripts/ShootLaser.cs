using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    public GameObject[] cover;
    public float targetLocalYPosition = 0.135f;
    public GameObject Die;

    private Vector3 currentVelocity;
    Laser laser;
    private void Start()
    {
        laser = new Laser(gameObject.transform.position, gameObject.transform.forward, material);
    }
    void Update()
    {
        GameObject obj = GameObject.Find("Laser");
        if (GameObject.Find("Laser") != null && laser.PuzzleSolved == false)
        {
            Destroy(obj);
            laser = new Laser(gameObject.transform.position, gameObject.transform.forward, material);
        }
        if (GameObject.Find("Laser") != null && laser.PuzzleSolved == true)
        {
            Destroy(obj, 1f);
            Destroy(Die, 5f);
            Invoke("MoveObjectsOnYAxis", 1.0f);
        }
    }

    void MoveObjectsOnYAxis()
    {
        foreach (GameObject obj in cover)
        {
            if (obj != null)
            {
                // ���� ������Ʈ�� Transform ������Ʈ ��������
                Transform objTransform = obj.transform;

                // ���� ���� ��ġ�� ������
                Vector3 currentLocalPosition = objTransform.localPosition;

                // y�� ���� ��ġ�� ��ǥ�� ����
                currentLocalPosition.y = targetLocalYPosition;

                // ���ο� ���� ��ġ�� ����
                objTransform.localPosition = currentLocalPosition;
            }
        }
    }
}
