using SimulationGame.Interface;
using Zenject;

namespace SimulationGame.Installer
{
    public class SimulationGameSignalInstaller : Installer<SimulationGameSignalInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<GameIsPausedSignal>();
            Container.DeclareSignal<ApplicationQuitSignal>();
        }
    }
}