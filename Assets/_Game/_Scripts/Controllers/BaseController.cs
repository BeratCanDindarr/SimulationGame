using System;
using Zenject;

namespace SimulationGame.Controller
{
    public abstract class BaseController: IInitializable, IDisposable
    {
        public abstract void Initialize();
        public abstract void Dispose();
    }
}