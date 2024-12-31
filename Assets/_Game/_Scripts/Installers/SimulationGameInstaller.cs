using SimulationGame.Controller;
using UnityEngine;
using Zenject;

namespace SimulationGame.Installer
{
    public class SimulationGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Controller
            Container.BindInterfacesAndSelfTo<ApplicationController>().AsSingle();
        }
    }
}