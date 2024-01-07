using System.Collections.Generic;

namespace Match3.GameCore
{
    public interface IGameBoardConnector
    {
        bool IsBlockMovementEligible(out string errorReason);
        void InitiatedBlockMovementEvent();
        void BlockMatchesEvent(List<List<(int row, int column, uint id)>> matchesInTheRow,
                               List<List<(int row, int column, uint id)>> matchesInTheColumn); //list of matches
    }
}
