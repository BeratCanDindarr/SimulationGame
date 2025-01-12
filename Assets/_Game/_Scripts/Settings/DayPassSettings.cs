using System;
using System.Collections.Generic;
using SimulationGame.Const;
using SimulationGame.Interface;
using UnityEngine;

namespace SimulationGame.Settings
{
    [CreateAssetMenu(fileName = nameof(DailyCycleSettings), menuName = MenuConst.SettingsMenu + nameof(DailyCycleSettings))]
    public class DailyCycleSettings : ScriptableObject
    {
        public List<DailyCycleData> DailyCycleDatas;
    }

    [Serializable]
    public class DailyCycleData
    {
        public Cubemap DayCubeMap;
        public DayPhaseType DayPhaseType;
        public long PassTime;
        //SkyTexture        
    }
}