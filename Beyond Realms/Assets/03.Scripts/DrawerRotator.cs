using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Rotates this object at a user defined speed
    /// </summary>
    public class DrawerRotator : MonoBehaviour
    {
        [SerializeField, Tooltip("Angular velocity in degrees per second")]
        Vector3 m_Velocity;

        bool m_IsRotating = true; // 회전 여부를 나타내는 변수 추가

        void Update()
        {
            if (m_IsRotating)
            {
                transform.Rotate(m_Velocity * Time.deltaTime);

                // z 축 각도가 180이 되면 회전 멈춤
                if (Mathf.Abs(transform.eulerAngles.z) >= 180f)
                {
                    m_IsRotating = false;
                }
            }
        }
    }
}