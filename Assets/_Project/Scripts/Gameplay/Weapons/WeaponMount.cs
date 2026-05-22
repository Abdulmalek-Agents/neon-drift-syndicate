using UnityEngine;
using UnityEngine.InputSystem;
namespace NeonDrift.Weapons
{
    public class WeaponMount : MonoBehaviour
    {
        [SerializeField] private WeaponDataSO equipped;
        [SerializeField] private Transform muzzle;
        private float _cooldownEnd;
        public void OnFire(InputAction.CallbackContext c)
        {
            if (!c.performed || equipped == null) return;
            if (Time.time < _cooldownEnd) return;
            _cooldownEnd = Time.time + equipped.cooldownSec;
            Instantiate(equipped.projectilePrefab, muzzle.position, muzzle.rotation);
        }
    }
}
