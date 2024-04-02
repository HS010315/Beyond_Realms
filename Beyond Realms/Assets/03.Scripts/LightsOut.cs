using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public BoxCollider pushObject;
    public GameObject[] button;
    public SphereCollider sphereCollider; // ��Ʈ�ѷ� �ݶ��̴�
    public Material[] materials;
    private int currentMaterialIndex = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("����");
        if (collision.collider == pushObject || collision.collider == sphereCollider)
        {
            foreach (GameObject btn in button)
            {
                Renderer renderer = btn.GetComponent<Renderer>();
                if (renderer != null && materials.Length > 0)
                {
                    currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
                    renderer.material = materials[currentMaterialIndex];
                }
            }
        }
    }
}