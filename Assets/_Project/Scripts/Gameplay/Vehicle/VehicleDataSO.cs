using UnityEngine;
namespace NeonDrift.Vehicle
{
    [CreateAssetMenu(menuName = "Neon Drift/Vehicle Data", fileName = "Vehicle_")]
    public class VehicleDataSO : ScriptableObject
    {
        public string vehicleId;
        public string displayName;
        public float topSpeedKmh = 280f;
        public float accelTimeTo100 = 4.5f;
        public float handling = 0.7f;
        public float massKg = 1200f;
        public int weaponSlots = 1;
        public Sprite icon;
        public GameObject prefab;
    }
}
