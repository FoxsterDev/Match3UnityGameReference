using NUnit.Framework;

namespace Match3.GameCore.Tests
{
    public class PossibleMatch3PatternTests
    {
        public static object[] BoardHasPossibleTheOneMatch3OfTheSameBlocksInTheRowCases =
        {
            new uint[,]
            {
                { 1, 2, 1, 1 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 2, 1, 2 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            }
            ,
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 2, 2, 1, 2 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            } ,
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 2, 2, 1, 2 },
                { 13, 14, 15, 16 }
            }
            ,
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 2, 2, 1, 2 },
            } ,
            new uint[,]
            {
                { 1, 2, 1, 1, 2 },
                { 5, 6, 7, 8, 2 },
                { 9, 10, 11, 12, 9 },
                { 13, 14, 15, 16, 7 },
            }
            ,
            new uint[,]
            {
                { 5, 6, 7, 8, 2 },
                { 1, 2, 1, 1, 2 },
                { 9, 10, 11, 12, 9 },
                { 13, 14, 15, 16, 7 },
            }
            ,
            new uint[,]
            {
                {2, 2, 1, 1, 2 },
                { 5, 6, 7, 8, 1 },
                { 9, 10, 11, 12, 9 },
                { 13, 14, 15, 16, 7 },
            } ,
            new uint[,]
            {
                { 9, 10, 11, 12, 9 },
                { 1, 2, 1, 1, 2 },
                { 5, 6, 7, 8, 2 },
                { 13, 14, 15, 16, 7 },
            },
            new uint[,]
            {
                { 9, 1, 11, 12, 9 },
                { 2, 2, 1, 1, 2 },
                { 5, 6, 7, 8, 2 },
                { 13, 14, 15, 16, 7 },
            },
            new uint[,]
            {
                { 9, 3, 11, 12, 9 },
                { 2, 2, 1, 1, 2 },
                { 5, 1, 7, 8, 2 },
                { 13, 14, 15, 16, 7 },
            }
            ,
            new uint[,]
            {
                { 9, 3, 11, 12, 9 },
                { 2, 2, 1, 1, 2 },
                { 5, 3, 7, 8, 1 },
                { 13, 14, 15, 16, 7 },
            },
            new uint[,]
            {
                { 9, 3, 11, 12, 9, 6 },
                { 2, 2, 1, 1, 2, 1 },
                { 5, 3, 7, 8, 2, 8 },
                { 13, 14, 15, 16, 7, 9 },
            },
            new uint[,]
            {
                { 9, 3, 11, 12, 1, 6 },
                { 2, 2, 1,  1,  2, 3 },
                { 5, 3, 7,  8,  2, 8 },
                { 13,14,15,16,  7, 9 },
            },
            new uint[,]
            {
                { 9, 3, 11, 12, 3, 6 },
                { 2, 2, 1,  1,  2, 3 },
                { 5, 3, 7,  8,  1, 8 },
                { 13,14,15,16,  7, 9 },
            },
            new uint[,]
            {
                { 9, 3, 11, 12, 3, 6 },
                { 13,14,15,16,  7, 9 },
                { 2, 2, 1,  1,  2, 3 },
                { 5, 3, 7,  8,  1, 8 },
            },
            new uint[,]
            {
                { 9, 3, 11, 12, 3, 6 },
                { 3, 4, 5,  6,  1, 9 },
                { 2, 2, 1,  1,  2, 3 },
                { 5, 3, 7,  8,  3, 8 },
            },
            new uint[,]
            {
                { 9, 3, 11, 12, 3, 6 },
                { 3, 4, 5,  6,  4, 9 },
                { 2, 2, 1,  1,  2, 1 },
                { 5, 3, 7,  8,  3, 8 },
            }
        };
        [Test]
        [TestCaseSource(nameof(BoardHasPossibleTheOneMatch3OfTheSameBlocksInTheRowCases))]
        public void isMatched_WhenBoardHasPossibleTheOneMatch3OfTheSameBlocksInTheRowCases_True(uint[,] board)
        {
            //arrange
            IPossibleMatchPattern pattern = new PossibleMatch3AndMorePatternInHorizontalOrVerticalForTheOneMove();

            //act
            var isMatched = pattern.IsPossibleMatched(board, out var matches, 0);

            //assert
            Assert.IsTrue(isMatched, "The board has at least one match in the row");
            //add additional asserts
        }
    }
}
