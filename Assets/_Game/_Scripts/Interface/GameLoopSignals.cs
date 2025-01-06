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
    
    public readonly struct LeftClickDownSignal { }
    public readonly struct LeftClickUpSignal { }
    public readonly struct JumpButtonClickedSignal { }
        
        
        
}