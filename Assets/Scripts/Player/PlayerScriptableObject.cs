using UnityEngine;

namespace AfterlifeArmory.Player
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView PlayerPrefab;
        public Vector3 SpawnPosition;
        public Vector3 SpawnRotation;
        public float MoveSpeed;
        public float RotationSpeed;
    }
}
