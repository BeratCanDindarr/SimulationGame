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
        private List<IFixedUpdate> _fixedUpdates = new List<IFixedUpdate>();
        private bool _isPaused = false;
        
        public void Subscribe(IUpdate obj)
        {
            if(_updates.Contains(obj)) return;
            _updates.Add(obj);
        }
        public void Subscribe(IFixedUpdate obj)
        {
            if(_fixedUpdates.Contains(obj)) return;
            _fixedUpdates.Add(obj);
        }

        public void Unsubscribe(IUpdate obj)
        {
            if(!_updates.Contains(obj))return;
            _updates.Remove(obj);
        } 
        public void Unsubscribe(IFixedUpdate obj)
        {
            if(!_fixedUpdates.Contains(obj))return;
            _fixedUpdates.Remove(obj);
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

        private void FixedUpdate()
        {
            if(!IsUpdateRunning())return;
            foreach (var fixedUpdate in _fixedUpdates) 
                fixedUpdate.FixedUpdate();
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