using System.IO;

namespace SimulationGame.Interface
{
    public readonly struct GameIsPausedSignal
    {
        public readonly bool IsPaused;

        public GameIsPausedSignal(bool paused)
        {
            IsPaused = paused;
        }
    }
        
    public readonly struct ApplicationQuitSignal { }
        
        
        
}