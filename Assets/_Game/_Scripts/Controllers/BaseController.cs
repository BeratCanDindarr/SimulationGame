using System;
using Zenject;

namespace SimulationGame.Controller
{
    public abstract class BaseController: IInitializable, IDisposable
    {
        #region Injection

        protected SignalBus signalBus;
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        #endregion
        public abstract void Initialize();
        public abstract void Dispose();
    }
}