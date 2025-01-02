using SimulationGame.Controller;
using SimulationGame.Interface;
using UnityEngine;

namespace SimulationGame
{
    public class DataController : BaseController
    {
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
