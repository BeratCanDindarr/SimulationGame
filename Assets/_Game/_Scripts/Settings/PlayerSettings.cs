using SimulationGame.Const;
using SimulationGame.View;
using UnityEngine;

namespace SimulationGame.Settings
{
    [CreateAssetMenu(fileName = nameof(PlayerSettings), menuName = MenuConst.SettingsMenu + nameof(PlayerSettings))]
    public class PlayerSettings : ScriptableObject
    {
        [Header("Player Settings")]
        [Space(20)]
        
        [Header("Prefab Settings")]
        public GameObject playerReference;

        public float PlayerHeight;
        public LayerMask GroundLayer;
        public float GroundDrag;
        public int PlayerSpeed;
        public float PlayerJumpForce;
        public float PlayerJumpCoolDown;
        public float PlayerAirMultiplier;
        
        [Header("Player Look Settings")]
        public float PlayerLookSensitivity;
        

    }
}