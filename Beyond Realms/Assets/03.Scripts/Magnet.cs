using UnityEngine;

public class Magnet: MonoBehaviour
{
    public string targetTag = "Key"; // 끌어당기는 대상의 태그
    public float pullForce = 10f; // 끌어당기는 힘의 세기
    public float stopDistance = 2f; // 멈추는 거리

    void FixedUpdate()
    {
        // 자기 자신의 위치
        Vector3 magnetPosition = transform.position;

        // 대상 오브젝트들을 배열로 가져오기
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        // 각 대상 오브젝트에 대해
        foreach (GameObject target in targets)
        {
            // 자석과 대상 사이의 거리 벡터
            Vector3 direction = magnetPosition - target.transform.position;

            // 끌어당기는 힘을 계산
            float distance = direction.magnitude;
            float pullStrength = 0f;

            // 일정 거리 이내에 있는 경우 멈추게 하기
            if (distance > stopDistance)
            {
                pullStrength = Mathf.Clamp(pullForce / distance, 0f, pullForce);
            }
            else
            {
                // 일정 거리 이내에 있으면 멈춤
                pullStrength = 0f;
            }

            // 대상에게 힘을 가하기
            target.GetComponent<Rigidbody>().AddForce(direction.normalized * pullStrength);
        }
    }
}