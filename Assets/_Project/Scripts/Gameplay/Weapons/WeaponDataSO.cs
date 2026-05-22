using UnityEngine;
namespace NeonDrift.Weapons
{
    public enum WeaponType { EMP, OilSlick, HomingMissile, BoostMine }
    [CreateAssetMenu(menuName = "Neon Drift/Weapon Data", fileName = "Weapon_")]
    public class WeaponDataSO : ScriptableObject
    {
        public string weaponId;
        public string displayName;
        public WeaponType type;
        public float cooldownSec = 6f;
        public float damage = 25f;
        public GameObject projectilePrefab;
        public Sprite icon;
    }
}
