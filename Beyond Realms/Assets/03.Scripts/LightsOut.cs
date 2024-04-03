using UnityEngine;

public class LightsOut : MonoBehaviour
{
    public GameObject[] buttons;
    public Material[] materials;
    private int[] buttonMaterialIndices; // 각 버튼에 대한 현재 재질 인덱스를 저장하는 배열

    private void Start()
    {
        buttonMaterialIndices = new int[buttons.Length];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Hand") || collision.collider.CompareTag("Button"))
        {
            // 각 버튼에 대해 처리합니다.
            for (int i = 0; i < buttons.Length; i++)
            {
                GameObject button = buttons[i];
                Renderer renderer = button.GetComponent<Renderer>();

                if (renderer != null && materials.Length > 0)
                {
                    // 현재 버튼의 재질 인덱스를 가져옵니다.
                    int currentMaterialIndex = buttonMaterialIndices[i];

                    // 현재 재질 인덱스를 사용하여 재질을 적용하고 다음 인덱스로 업데이트합니다.
                    renderer.material = materials[currentMaterialIndex];
                    buttonMaterialIndices[i] = (currentMaterialIndex + 1) % materials.Length;
                }
            }
        }
    }
}