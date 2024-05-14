using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace Unity.VRTemplate
{
    /// <summary>
    /// An interactable knob that follows the rotation of the interactor
    /// </summary>
    public class XRLever : XRBaseInteractable
    {
        [SerializeField]
        [Tooltip("The object that is visually grabbed and manipulated")]
        Transform m_Handle = null;

        [SerializeField]
        [Tooltip("Angle increments to support, if greater than '0'")]
        float m_AngleIncrement = 0.0f;

        [SerializeField]
        [Tooltip("The minimum angle of the lever")]
        float m_MinAngle = -45.0f;

        [SerializeField]
        [Tooltip("The maximum angle of the lever")]
        float m_MaxAngle = 45.0f;

        [System.Serializable]
        public class ValueChangeEvent : UnityEvent<float, float> { } // ValueChangeEvent Á¤ÀÇ


        [SerializeField]
        [Tooltip("Events to trigger when the lever is rotated")]
        ValueChangeEvent m_OnValueChange = new ValueChangeEvent();

        IXRSelectInteractor m_Interactor;

        float m_BaseLeverRotationX = 0.0f;
        float m_BaseLeverRotationZ = 0.0f;

        /// <summary>
        /// The object that is visually grabbed and manipulated
        /// </summary>
        public Transform handle
        {
            get => m_Handle;
            set => m_Handle = value;
        }

        /// <summary>
        /// The minimum angle of the lever
        /// </summary>
        public float minAngle
        {
            get => m_MinAngle;
            set => m_MinAngle = value;
        }

        /// <summary>
        /// The maximum angle of the lever
        /// </summary>
        public float maxAngle
        {
            get => m_MaxAngle;
            set => m_MaxAngle = value;
        }

        /// <summary>
        /// Events to trigger when the lever is rotated
        /// </summary>
        public ValueChangeEvent onValueChange => m_OnValueChange;

        void Start()
        {
            SetLeverRotation(m_BaseLeverRotationX, m_BaseLeverRotationZ);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            selectEntered.AddListener(StartGrab);
            selectExited.AddListener(EndGrab);
        }

        protected override void OnDisable()
        {
            selectEntered.RemoveListener(StartGrab);
            selectExited.RemoveListener(EndGrab);
            base.OnDisable();
        }

        void StartGrab(SelectEnterEventArgs args)
        {
            m_Interactor = args.interactorObject;
            UpdateBaseLeverRotation();
            UpdateRotation();
        }

        void EndGrab(SelectExitEventArgs args)
        {
            m_Interactor = null;
        }

        /// <inheritdoc />
        public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
        {
            base.ProcessInteractable(updatePhase);

            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            {
                if (isSelected)
                {
                    UpdateRotation();
                }
            }
        }

        /// <inheritdoc />
        public override Transform GetAttachTransform(IXRInteractor interactor)
        {
            return m_Handle;
        }

        void UpdateRotation()
        {
            var interactorTransform = m_Interactor.GetAttachTransform(this);
            var localForward = transform.InverseTransformDirection(interactorTransform.forward);
            var localUp = transform.InverseTransformDirection(interactorTransform.up);

            var leverRotationX = Mathf.Atan2(localForward.z, localForward.y) * Mathf.Rad2Deg;
            var leverRotationZ = Mathf.Atan2(localUp.z, localUp.y) * Mathf.Rad2Deg; 

            SetLeverRotation(leverRotationX, leverRotationZ);
        }

        void SetLeverRotation(float xRotation, float zRotation)
        {
            if (m_AngleIncrement > 0)
            {
                var normalizeXRotation = xRotation;
                var normalizeZRotation = zRotation;

                xRotation = (Mathf.Round(normalizeXRotation / m_AngleIncrement) * m_AngleIncrement);
                zRotation = (Mathf.Round(normalizeZRotation / m_AngleIncrement) * m_AngleIncrement);
            }

            if (m_Handle != null)
                m_Handle.localEulerAngles = new Vector3(
                    Mathf.Clamp(xRotation, m_MinAngle, m_MaxAngle),
                    0.0f,
                    Mathf.Clamp(zRotation, m_MinAngle, m_MaxAngle));

            InvokeOnValueChange(xRotation, zRotation);
        }
        void UpdateBaseLeverRotation()
        {
            var localForward = transform.InverseTransformDirection(m_Interactor.transform.forward);
            var localRight = transform.InverseTransformDirection(m_Interactor.transform.right);

            m_BaseLeverRotationX = Mathf.Atan2(localForward.z, localForward.y) * Mathf.Rad2Deg;
            m_BaseLeverRotationZ = Mathf.Atan2(localRight.z, localRight.y) * Mathf.Rad2Deg;
        }

        void InvokeOnValueChange(float xRotation, float zRotation)
        {
            m_OnValueChange.Invoke(xRotation, zRotation);
        }
    }
}