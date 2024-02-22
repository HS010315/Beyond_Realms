using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    // 문 오브젝트 변수
    public GameObject doorObject;

    // 문의 Y 축 이동 거리
    public float doorMoveDistance = -1.6f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Key"))
        {
            Destroy(gameObject);
            // 문이 존재하는지 확인 후 이동
            if (doorObject != null)
            {
                // 문의 현재 위치
                Vector3 doorPosition = doorObject.transform.position;
                // 새로운 Y 포지션 설정
                doorPosition.y += doorMoveDistance;
                // 문의 위치 업데이트
                doorObject.transform.position = doorPosition;
            }
            
        }

    }
}