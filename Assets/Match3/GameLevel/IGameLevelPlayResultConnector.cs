namespace Match3.GameCore
{
    public interface IGameLevelPlayResultConnector
    {
        void FinishedLevelEvent(uint score);
    }
}
