using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using SimulationGame.Interface;
using UnityEngine;
using Zenject;

namespace SimulationGame.View
{
    public class GameLoopView : BaseView
    {
        private List<IUpdate> _updates = new List<IUpdate>();
        private bool _isPaused = false;

        public void Init()
        {
            //Update();
        }
        public void Subscribe(IUpdate obj)
        {
            if(_updates.Contains(obj)) return;
            _updates.Add(obj);
        }

        public void Unsubscribe(IUpdate obj)
        {
            if(!_updates.Contains(obj))return;
            _updates.Remove(obj);
        }

        private bool IsUpdateRunning()
        {
            return _updates.Count != 0;
        }
        private void Update()
        {
            if(!IsUpdateRunning())return;
            foreach (var updatedObj in _updates) 
                updatedObj.Update();
        }

        private void OnApplicationQuit()
        {
            _signalBus.Fire(new ApplicationQuitSignal());
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            _isPaused = pauseStatus;
            _signalBus.Fire(new GameIsPausedSignal(pauseStatus));
        }
    }
}