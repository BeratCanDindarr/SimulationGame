using System;
using SimulationGame.Const;
using UnityEngine;
using Zenject;

namespace SimulationGame.Installer
{
    [CreateAssetMenu(fileName = nameof(SettingsInstaller), menuName = MenuConst.SettingsMenu + nameof(SettingsInstaller), order = 0)]
    public class SettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ScriptableObject[] settings;

        public override void InstallBindings()
        {
            foreach (var setting in settings)
            {
                Container.BindInterfacesAndSelfTo(setting.GetType()).FromInstance(setting);
            }
        }
    }
}