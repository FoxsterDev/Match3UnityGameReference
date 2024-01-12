using System.Collections.Generic;
using UnityEngine;

namespace Match3.GameCore
{
    public class GameLevelConfigGenerator
    {
        readonly GameLevelTemplateConfig _levelTemplateConfig;

        public GameLevelConfigGenerator(GameLevelTemplateConfig levelTemplateConfig)
        {
            _levelTemplateConfig = levelTemplateConfig;
        }

        public GameLevelConfig Generate(GameLevelConfig original)
        {
            var randomBlocksGenerator = new GameBoardBlocksGenerator(_levelTemplateConfig.MinBlockId, _levelTemplateConfig.MaxBlockId);

            IMatchPattern matchPattern = new MatchSomeCountInHorizontalOrVerticalPattern();
            IPossibleMatchPattern possibleMatchPattern = new PossibleMatch3PatternInHorizontalOrVerticalForTheOneMove();
            var tryCount = 20;

            var output = new List<(uint[,] outBoard, int matchesCount, int possibleMatchesCount)>();
            do
            {
                var column = Random.Range((int)_levelTemplateConfig.MinColumnCount, (int)_levelTemplateConfig.MaxColumnCount + 1);
                var row = Random.Range((int)_levelTemplateConfig.MinRowCount, (int)_levelTemplateConfig.MaxRowCount + 1);

                var emptyBoard = new uint[row, column];
                uint[,] outBoard;
                randomBlocksGenerator.Generate(emptyBoard, out var newBlocks,  out  outBoard);

                var hasMatch = matchPattern.IsMatched(
                    outBoard,
                    out var matchesInTheRow,
                    out var matchesInTheColumn,
                    BlockEntity.EMPTY_ID);

                possibleMatchPattern.IsPossibleMatched(outBoard, out var possibleMatches, 0);
                var matchesCount = (matchesInTheRow.Count + matchesInTheColumn.Count);
                var possibleMatchesCount = possibleMatches.Count;
                output.Add((outBoard, matchesCount, possibleMatchesCount ) );
            }
            while (tryCount-- > 0);

            uint[,] theBestOutBoard = null;
            foreach (var res in output)
            {
                if (res.matchesCount == 0 && res.possibleMatchesCount > 0)
                {
                    theBestOutBoard = res.outBoard;
                }
            }

            if (theBestOutBoard == null)
            {
                foreach (var res in output)
                {
                    if (res.matchesCount > 0)
                    {
                        theBestOutBoard = res.outBoard;
                    }
                }
            }

            if (theBestOutBoard == null)
            {
                Debug.LogError("Could not generate random board with required conditions");
                return null;
            }

            var rowCount = theBestOutBoard.GetLength(0);
            var columnCount = theBestOutBoard.GetLength(1);
            var blocksCount = (int) (columnCount * rowCount);
            var blocks = new List<BlockConfig>(blocksCount);
            for (var row = 0; row < rowCount; row++)
            {
                for (var col = 0; col < columnCount; col++)
                {
                    var index = (int) (row * columnCount + col);
                    var obj = _levelTemplateConfig.AllowedBlocks.Find(a => ((IBlockView) a).ID == theBestOutBoard[row, col]);
                    //Debug.Log("Index" + index +",Row "+ rowCount+" ,Column "+ columnCount);
                    blocks.Insert(index, new BlockConfig(obj.gameObject) ); //[index] =;
                }
            }

            var levelConfig = (GameLevelConfig)Object.Instantiate(original);
            levelConfig.Modify((uint)rowCount, 
                               (uint)columnCount, 
                               blocks, 
                               _levelTemplateConfig.MinBlockId, 
                               _levelTemplateConfig.MaxBlockId, new Vector2(1f - columnCount*0.1f, -1f));
            return levelConfig;
        }
    }
}
