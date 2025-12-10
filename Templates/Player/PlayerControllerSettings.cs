using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerControllerSettings", menuName = "Player/Player Controller Settings")]
    public class PlayerControllerSettings : ScriptableObject
    {
        [Header("Movement Settings")]
        [Range(0.5f, 20f)]
        public float moveSpeed = 5f;
        
        [Header("Jump Settings")]
        [Range(0.5f, 10f)]
        public float jumpHeight = 2f;
        
        [Header("Gravity & Grounding")]
        [Range(-30f, -5f)]
        public float gravity = -9.81f;
        
        [Tooltip("Small downward force applied when grounded to keep character stable")]
        [Range(-5f, -0.1f)]
        public float groundingForce = -2f;
    }
}
