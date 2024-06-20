using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPrefabver : MonoBehaviour
{
    public GameObject laserPrefab;         // �߻��� ������ ������
    public Transform laserSpawnPoint;      // ������ �߻� ��ġ
    public float laserSpeed = 20f;          // ������ �߻� �ӵ�
    public float maxLaserLength = 105f;     // �������� �ִ� ����

    private GameObject currentLaser;
    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool isShooting = false;

    void Start()
    {
        originalScale = laserPrefab.transform.localScale;
        targetScale = new Vector3(originalScale.x, originalScale.y, maxLaserLength);
        StartCoroutine(FireLaser());
    }

    IEnumerator FireLaser()
    {
        isShooting = true;
        currentLaser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
        currentLaser.transform.localScale = new Vector3(originalScale.x, originalScale.y, 0);

        float currentLength = 0f;
        while (currentLength < maxLaserLength)
        {
            currentLength += laserSpeed * Time.deltaTime;
            float clampedLength = Mathf.Clamp(currentLength, 0f, maxLaserLength);
            currentLaser.transform.localScale = new Vector3(originalScale.x, originalScale.y, clampedLength);
            yield return null;
        }

        Destroy(currentLaser);
        isShooting = false;
    }
}