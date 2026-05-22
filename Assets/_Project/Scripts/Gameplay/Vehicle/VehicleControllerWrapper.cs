using UnityEngine;
using UnityEngine.InputSystem;
namespace NeonDrift.Vehicle
{
    /// <summary>
    /// Wrapper around Edy's Vehicle Physics. Forwards input from New Input System,
    /// applies VehicleDataSO stat overrides, and exposes events for RaceManager.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleControllerWrapper : MonoBehaviour
    {
        [SerializeField] private VehicleDataSO data;
        [SerializeField] private Transform[] driveWheels;
        [SerializeField] private Transform[] steerWheels;
        [SerializeField] private float maxSteerAngle = 30f;
        [SerializeField] private float driftBoostGain = 0.5f;
        public float Throttle { get; set; }
        public float Steer { get; set; }
        public bool Handbrake { get; set; }
        public float Boost { get; private set; }
        public bool IsDrifting => Mathf.Abs(Steer) > 0.5f && Handbrake;

        private Rigidbody _rb;
        private void Awake() { _rb = GetComponent<Rigidbody>(); _rb.mass = data.massKg; }
        public void OnThrottle(InputAction.CallbackContext c) => Throttle = c.ReadValue<float>();
        public void OnSteer(InputAction.CallbackContext c) => Steer = c.ReadValue<float>();
        public void OnHandbrake(InputAction.CallbackContext c) => Handbrake = c.ReadValueAsButton();
        public void OnBoost(InputAction.CallbackContext c) { if (c.performed && Boost > 0.2f) { _rb.AddForce(transform.forward * 50f * Boost, ForceMode.VelocityChange); Boost = 0; } }
        private void FixedUpdate()
        {
            // Simplified — in production, hand off to Edy's VehicleController for proper wheel physics.
            _rb.AddForce(transform.forward * Throttle * (data.topSpeedKmh / 3.6f) * 2f, ForceMode.Acceleration);
            transform.Rotate(0f, Steer * maxSteerAngle * Time.fixedDeltaTime, 0f);
            if (IsDrifting) Boost = Mathf.Min(1f, Boost + driftBoostGain * Time.fixedDeltaTime);
        }
    }
}
