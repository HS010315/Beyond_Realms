using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoyStickController : XRBaseInteractable
{
    public Transform handle; // ������ �ڵ�
    public float sensitivity = 1f; // ���� ����
    public float maxRotationAngleX = 45f; // x �� �ִ� ȸ�� ���� (�¿� ����)
    public float maxRotationAngleZ = 30f; // z �� �ִ� ȸ�� ���� (���� ����)

    private Quaternion initialRotation; // �ʱ� ȸ����
    private float currentRotationAngleX = 0f; // ���� x �� ȸ�� ����
    private float currentRotationAngleZ = 0f; // ���� z �� ȸ�� ����

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
            currentRotationAngleX += input.x * sensitivity;
            currentRotationAngleX = Mathf.Clamp(currentRotationAngleX, -maxRotationAngleX, maxRotationAngleX);

            currentRotationAngleZ += input.y * sensitivity;
            currentRotationAngleZ = Mathf.Clamp(currentRotationAngleZ, -maxRotationAngleZ, maxRotationAngleZ);

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