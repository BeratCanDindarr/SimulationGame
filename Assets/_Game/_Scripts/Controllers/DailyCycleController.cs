using System.Linq;
using SimulationGame.Interface;
using SimulationGame.Settings;
using UnityEngine;

namespace SimulationGame.Controller
{
    public class DailyCycleController : ITimer
    {
        public DailyCycleSaveData DailyCycleSaveData;

        #region Inject

        private TimerController _timerController;
        private DailyCycleSettings _dailyCycleSettings;
        public DailyCycleController(TimerController timerController
            , DailyCycleSettings dailyCycleSettings)
        {
            _timerController = timerController;
            _dailyCycleSettings = dailyCycleSettings;
        }

        #endregion
        
        public void Init()
        {
            _timerController.Subscribe(this);
        }

        public void UpdateTime(long elapsedTime)
        {
            var dayPhaseData = _dailyCycleSettings.DailyCycleDatas.FirstOrDefault(dayPhase =>
                dayPhase.DayPhaseType == DailyCycleSaveData.CurrentDailyPhasePhaseType);
            if(dayPhaseData == null) return;
            if(dayPhaseData.PassTime <= 0) ChangeDayPhase(dayPhaseData.DayPhaseType);
            dayPhaseData.PassTime -= elapsedTime;
            Debug.Log("DayPhasetype" + DailyCycleSaveData.CurrentDailyPhasePhaseType + "passedTime:" + DailyCycleSaveData.PassedTime);
        }

        private void ChangeDayPhase(DayPhaseType dayPhaseType)
        {
            int dayPhaseValue = ((int)dayPhaseType+1);
            if (dayPhaseValue >= (int)DayPhaseType.DayPhaseCount) dayPhaseValue = 0;
            DailyCycleSaveData.CurrentDailyPhasePhaseType = (DayPhaseType)dayPhaseValue;
        }
    }

    public class DailyCycleSaveData
    {
        public DayPhaseType CurrentDailyPhasePhaseType;
        public float PassedTime;
    }
}