using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using SimulationGame.Interface;
using UnityEngine;

namespace SimulationGame.Controller
{
    public class TimerController
    {
        private List<ITimer> _timers;
        public void Init()
        {
            _timers = new List<ITimer>();
            UpdateTime().Forget();
        }

        public void Subscribe(ITimer timer)
        {
            if(_timers.Contains(timer)) return;
            _timers.Add(timer);
        }

        public void Unsubscribe(ITimer timer)
        {
            if(!_timers.Contains(timer)) return;
            _timers.Remove(timer);
        }

        private async UniTaskVoid UpdateTime()
        {
            foreach (var timer in _timers)timer.UpdateTime(1);
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            UpdateTime();
        }
    }
}
