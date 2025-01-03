using UnityEditor;
using UnityEngine;
using Zenject;

namespace SimulationGame.View
{
    public abstract class BaseView : MonoBehaviour
    {
        #region Inject

        protected SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        #endregion
        

        public void DestroyView(float delay = 0)
        {
            DestroyView();
            Destroy(this.gameObject,delay);
        }

        protected virtual void DestroyView()
        {
            
        }
    }
}