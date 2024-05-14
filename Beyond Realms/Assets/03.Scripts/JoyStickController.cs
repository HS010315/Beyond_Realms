using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoyStickController : XRBaseInteractable
{
    public Transform handle; // ������ �ڵ�
    public float sensitivity = 1f; // ���� ����
    public float maxRotationAngleX = 45f; // x �� �ִ� ȸ�� ���� (�¿� ����)
    public float maxRotationAngleZ = 45f; // z �� �ִ� ȸ�� ���� (���� ����)

    private Quaternion initialRotation; // �ʱ� ȸ����

    protected override void Awake()
    {
        base.Awake();
        initialRotation = handle.rotation;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected && selectingInteractor != null)
        {
            Vector2 input = GetControllerInput(selectingInteractor);
            float currentRotationAngleX = Mathf.Clamp(input.x * sensitivity, -maxRotationAngleX, maxRotationAngleX);
            float currentRotationAngleZ = Mathf.Clamp(input.y * sensitivity, -maxRotationAngleZ, maxRotationAngleZ);

            Quaternion newRotation = Quaternion.Euler(currentRotationAngleZ, 0f, currentRotationAngleX);
            handle.rotation = initialRotation * newRotation;
        }
    }

    private Vector2 GetControllerInput(XRBaseInteractor interactor)
    {
        // ���ͷ����� ��ġ ��ȭ�� �����Ͽ� �Է� �� ��ȯ
        Vector3 interactorPosition = interactor.transform.position;
        Vector3 startingPosition = interactor.attachTransform.position;
        Vector3 movementDirection = interactorPosition - startingPosition;
        movementDirection = transform.InverseTransformDirection(movementDirection);

        float inputX = movementDirection.x;
        float inputY = movementDirection.z;

        return new Vector2(inputX, inputY);
    }
}