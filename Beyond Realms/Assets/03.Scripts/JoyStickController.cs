using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JoyStickController : XRBaseInteractable
{
    public Transform handle; // 조작할 핸들
    public float sensitivity = 1f; // 조작 감도
    public float maxRotationAngleX = 45f; // x 축 최대 회전 각도 (좌우 제한)
    public float maxRotationAngleZ = 30f; // z 축 최대 회전 각도 (상하 제한)

    private Quaternion initialRotation; // 초기 회전값
    private float currentRotationAngleX = 0f; // 현재 x 축 회전 각도
    private float currentRotationAngleZ = 0f; // 현재 z 축 회전 각도

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
        // 인터랙터의 위치 변화를 감지하여 입력 값 반환
        Vector3 interactorPosition = interactor.transform.position;
        Vector3 startingPosition = interactor.attachTransform.position;
        Vector3 movementDirection = interactorPosition - startingPosition;
        movementDirection = transform.InverseTransformDirection(movementDirection);

        float inputX = movementDirection.x;
        float inputY = movementDirection.z;

        return new Vector2(inputX, inputY);
    }
}