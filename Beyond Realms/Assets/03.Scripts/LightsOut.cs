using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public GameObject[] buttons;
    public Material[] materials;
    private int[] buttonMaterialIndices; // �� ��ư�� ���� ���� ���� �ε����� �����ϴ� �迭

    private void Start()
    {
        buttonMaterialIndices = new int[buttons.Length];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hand") || collision.collider.CompareTag("Button"))
        {
            // �� ��ư�� ���� ó���մϴ�.
            for (int i = 0; i < buttons.Length; i++)
            {
                GameObject button = buttons[i];
                Renderer renderer = button.GetComponent<Renderer>();

                if (renderer != null && materials.Length > 0)
                {
                    // ���� ��ư�� ���� �ε����� �����ɴϴ�.
                    int currentMaterialIndex = buttonMaterialIndices[i];

                    // ���� ���� �ε����� ����Ͽ� ������ �����ϰ� ���� �ε����� ������Ʈ�մϴ�.
                    renderer.material = materials[currentMaterialIndex];
                    buttonMaterialIndices[i] = (currentMaterialIndex + 1) % materials.Length;
                }
            }
        }
    }
}