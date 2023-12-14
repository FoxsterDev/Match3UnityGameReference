namespace Match3.GameCore
{
    public interface IMatchPattern
    {
        bool IsMatched(BlockEntity[,] board);
        bool IsMatched(uint[,] board);

    }
}
