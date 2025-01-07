using SimulationGame.Const;
using SimulationGame.Controller;
using SimulationGame.Interface;
using UnityEngine;

namespace SimulationGame
{
    public class DataController : BaseController
    {
        #region Injection

        private readonly DailyCycleController _dailyCycleController;
        public DataController(DailyCycleController dailyCycleController)
        {
            _dailyCycleController = dailyCycleController;
        }

        #endregion
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Initialize()
        {
           
        }

        public void Init()
        {
            LoadData();
            Subscribe();
        }

        private void Subscribe()
        {
            signalBus.Subscribe<GameIsPausedSignal>(PauseGame);
            signalBus.Subscribe<ApplicationQuitSignal>(ApplicationQuit);
        }

        private void ApplicationQuit()
        {
            SaveData();
        }

        private void PauseGame(GameIsPausedSignal signal)
        {
            if (signal.IsPaused)
            {
                SaveData();
                return;
            }
            LoadData();
        }

        private void LoadData()
        {
            var levelTest =  JsonUtility.FromJson<TestSave>(PlayerPrefs.GetString("PlayerLevel"));
            _dailyCycleController.DailyCycleSaveData = JsonUtility.FromJson<DailyCycleSaveData>
                (PlayerPrefs.GetString(GlobalConst.SaveDataName.DAILY_CYCLE_SAVE,JsonUtility.ToJson(new DailyCycleSaveData()
                {
                    CurrentDailyPhasePhaseType = DayPhaseType.Morning,
                    PassedTime = 0
                })));
            Debug.Log(levelTest.level.ToString());
        }

        private void SaveData()
        {
            //Save Basic Imp
            var testSave = new TestSave()
            {
                level = 10
            };
            PlayerPrefs.SetString("PlayerLevel",JsonUtility.ToJson(testSave));
            PlayerPrefs.SetString(GlobalConst.SaveDataName.DAILY_CYCLE_SAVE,JsonUtility.ToJson(_dailyCycleController.DailyCycleSaveData));
        }

        public void Unsubscribe()
        {
            signalBus.TryUnsubscribe<GameIsPausedSignal>(PauseGame);
            signalBus.TryUnsubscribe<ApplicationQuitSignal>(ApplicationQuit);
        }
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Dispose()
        {
            SaveData();
            Unsubscribe();
        }
        
        private class TestSave
        {
            public int level;
        }
    }
}
