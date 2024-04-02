using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public BoxCollider pushObject;
    public GameObject[] button;
    public SphereCollider sphereCollider; // 컨트롤러 콜라이더
    public Material[] materials;
    private int currentMaterialIndex = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ㅎㅇ");
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