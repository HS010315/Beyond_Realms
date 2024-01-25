using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip footstepClip; // �߼Ҹ� ����� Ŭ��

    private Vector3 lastPosition; // ���� �������� ��ġ

    void Start()
    {
        // �ʱ� ��ġ ����
        lastPosition = transform.position;
    }

    void Update()
    {
        // ���� ��ġ�� ���� �������� ��ġ�� ���Ͽ� ������ ����
        if (Vector3.Distance(transform.position, lastPosition) > 0.01f)
        {
            PlayFootstepSound();
        }
        else
        {
            StopFootstepSound();
        }

        // ���� �������� ��ġ ������Ʈ
        lastPosition = transform.position;
    }

    void PlayFootstepSound()
    {
        // ���� �߼Ҹ��� ��� ���� �ƴ϶�� ����� Ŭ���� ���� ���
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().PlayOneShot(footstepClip);
        }
    }

    void StopFootstepSound()
    {
        // �߼Ҹ� ����
        GetComponent<AudioSource>().Stop();
    }
}