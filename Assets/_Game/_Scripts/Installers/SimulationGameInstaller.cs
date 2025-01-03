using SimulationGame.Controller;
using UnityEngine;
using Zenject;

namespace SimulationGame.Installer
{
    public class SimulationGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SimulationGameSignalInstaller.Install(Container);
            //Controller
            Container.BindInterfacesAndSelfTo<ApplicationController>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
            Container.BindInterfacesAndSelfTo<DataController>().AsSingle();
        }
    }
}