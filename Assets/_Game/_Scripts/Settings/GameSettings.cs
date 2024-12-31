using SimulationGame.Const;
using UnityEngine;

namespace SimulationGame.Settings
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = MenuConst.SettingsMenu + nameof(GameSettings))]
    public class GameSettings : ScriptableObject
    {
        public string ID;
    }
}