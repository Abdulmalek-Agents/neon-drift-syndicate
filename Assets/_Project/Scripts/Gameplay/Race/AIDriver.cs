using UnityEngine;
using UnityEngine.Splines;
namespace NeonDrift.Race
{
    /// <summary>
    /// Simple spline-following AI driver. Rubber-bands to player speed.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class AIDriver : MonoBehaviour
    {
        [SerializeField] private SplineContainer trackSpline;
        [SerializeField] private Transform playerForRubberBand;
        [SerializeField] private float baseSpeed = 30f;
        [SerializeField] private float rubberBandFactor = 0.15f;
        private float _t;

        private void Update()
        {
            if (trackSpline == null) return;
            float playerSpeed = playerForRubberBand ? playerForRubberBand.GetComponent<Rigidbody>().linearVelocity.magnitude : baseSpeed;
            float speed = baseSpeed + (playerSpeed - baseSpeed) * rubberBandFactor;
            _t += speed * Time.deltaTime / trackSpline.CalculateLength();
            if (_t > 1f) _t -= 1f;
            var pos = trackSpline.EvaluatePosition(_t);
            var tan = trackSpline.EvaluateTangent(_t);
            transform.position = pos;
            if (((Vector3)tan).sqrMagnitude > 0.001f) transform.rotation = Quaternion.LookRotation((Vector3)tan);
        }
    }
}
