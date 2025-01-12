using System.Linq;
using SimulationGame.Interface;
using SimulationGame.Settings;
using SimulationGame.View;
using UnityEngine;

namespace SimulationGame.Controller
{
    public class DailyCycleController : ITimer
    {
        public DailyCycleSaveData DailyCycleSaveData;

        #region Inject

        private TimerController _timerController;
        private DailyCycleSettings _dailyCycleSettings;
        private SkyBoxView _skyBoxView;
        public DailyCycleController(TimerController timerController
            , DailyCycleSettings dailyCycleSettings
            , SkyBoxView skyBoxView)
        {
            _timerController = timerController;
            _dailyCycleSettings = dailyCycleSettings;
            _skyBoxView = skyBoxView;
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
            DailyCycleSaveData.PassedTime += elapsedTime;
            if(dayPhaseData.PassTime > DailyCycleSaveData.PassedTime) return;
            ChangeDayPhase(dayPhaseData.DayPhaseType);
            _skyBoxView.ChangeSkyBox(dayPhaseData.DayCubeMap);
            Debug.Log("DayPhasetype" + DailyCycleSaveData.CurrentDailyPhasePhaseType + "passedTime:" + DailyCycleSaveData.PassedTime);
        }

        private void ChangeDayPhase(DayPhaseType dayPhaseType)
        {
            int dayPhaseValue = ((int)dayPhaseType+1);
            if (dayPhaseValue >= (int)DayPhaseType.DayPhaseCount) dayPhaseValue = 0;
            DailyCycleSaveData.CurrentDailyPhasePhaseType = (DayPhaseType)dayPhaseValue;
            DailyCycleSaveData.PassedTime = 0;
        }
    }

    public class DailyCycleSaveData
    {
        public DayPhaseType CurrentDailyPhasePhaseType;
        public float PassedTime;
    }
}