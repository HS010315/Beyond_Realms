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

        bool m_IsRotating = true; // ȸ�� ���θ� ��Ÿ���� ���� �߰�

        void Update()
        {
            if (m_IsRotating)
            {
                transform.Rotate(m_Velocity * Time.deltaTime);

                // z �� ������ 180�� �Ǹ� ȸ�� ����
                if (Mathf.Abs(transform.eulerAngles.z) >= 180f)
                {
                    m_IsRotating = false;
                }
            }
        }
    }
}