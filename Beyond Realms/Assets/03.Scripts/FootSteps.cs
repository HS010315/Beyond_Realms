using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip footstepClip; // 발소리 오디오 클립

    private Vector3 lastPosition; // 이전 프레임의 위치

    void Start()
    {
        // 초기 위치 설정
        lastPosition = transform.position;
    }

    void Update()
    {
        // 현재 위치와 이전 프레임의 위치를 비교하여 움직임 감지
        if (Vector3.Distance(transform.position, lastPosition) > 0.01f)
        {
            PlayFootstepSound();
        }
        else
        {
            StopFootstepSound();
        }

        // 이전 프레임의 위치 업데이트
        lastPosition = transform.position;
    }

    void PlayFootstepSound()
    {
        // 현재 발소리가 재생 중이 아니라면 오디오 클립을 직접 재생
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().PlayOneShot(footstepClip);
        }
    }

    void StopFootstepSound()
    {
        // 발소리 중지
        GetComponent<AudioSource>().Stop();
    }
}