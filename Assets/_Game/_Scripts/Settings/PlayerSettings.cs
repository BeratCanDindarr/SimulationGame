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

        public int PlayerSpeed;
        public int PlayerJumpForce;
        
        [Header("Player Look Settings")]
        public float PlayerLookSensitivity;
        

    }
}