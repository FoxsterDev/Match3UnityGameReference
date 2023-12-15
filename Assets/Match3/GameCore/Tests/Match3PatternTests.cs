using NUnit.Framework;

namespace Match3.GameCore.Tests
{
    public class Match3PatternTests
    {
        public static object[] BoardHasFewMatches3OrMoreOfTheSameBlocksInTheRowCases =
        {
            new uint[,]
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 3, 6, 6, 6, 6 },
                { 9, 10, 11, 12, 13 },
                { 13, 14, 15, 15,15 }
            }
            ,
            new uint[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 },
            }
            ,
            new uint[,]
            {
                { 2, 1, 1, 1, 25 },
                { 5, 6, 6, 6, 6 },
                { 10, 11, 12, 12, 12 },
                { 13, 14, 16, 16, 16 }
            }
        };

        public static object[] BoardHasMoreThan3OfTheSameBlocksInTheRowCases =
        {
            new uint[,]
            {
                { 1, 1, 1, 1 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 5, 6, 6, 6, 6 },
                { 9, 10, 11, 12, 13 },
                { 13, 14, 15, 16,16 }
            }
            ,
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 5, 6, 6, 6, 6 },
                { 10, 10, 10, 10, 10 },
                { 13, 14, 15, 16,16 }
            }
            ,
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 5, 6, 6, 6, 6 },
                { 10, 10, 10, 10, 10 },
                { 13, 16, 16, 16, 16 }
            }
        };

        public static object[] BoardHas3OfTheSameBlocksInTheRowCases =
        {
            new uint[,]
            {
                { 1, 1, 1, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 1, 1, 1 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 6, 6 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 7 },
                { 9, 9, 9, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 7 },
                { 9, 10, 10, 10 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 7 },
                { 9, 10, 11, 12 },
                { 13, 13, 13, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 7 },
                { 9, 10, 11, 12 },
                { 14, 13, 13, 13 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4, 25 },
                { 5, 6, 7, 7, 26 },
                { 9, 10, 11, 12, 27 },
                { 14, 13, 13, 13, 28 }
            }
        };
        public static object[] BoardHas3OfTheSameBlocksInTheColumnCases =
        {
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 1, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 3, 2, 2 },
                { 1, 6, 7, 8 },
                { 1, 10, 11, 12 },
                { 1, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 6, 7, 8, 9 },
                { 6, 10, 11, 12 },
                { 6, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 9, 7, 7 },
                { 9, 9, 8, 12 },
                { 13, 9, 15, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 10, 7 },
                { 9, 11, 10, 12 },
                { 13, 14, 10, 16 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 7 },
                { 9, 10, 11, 7 },
                { 3, 1, 3, 7 }
            },
            new uint[,]
            {
                { 1, 2, 4, 4 },
                { 5, 6, 4, 7 },
                { 9, 10, 4, 12 },
                { 14, 1, 13, 13 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4, 25 },
                { 5, 6, 7, 7, 26 },
                { 9, 10, 11, 7, 27 },
                { 14, 13, 13, 7, 28 },
                { 14, 1, 3, 1, 28 }
            }
        };

        [Test]
        [TestCaseSource(nameof(BoardHas3OfTheSameBlocksInTheColumnCases))]
        public void isMatched_WhenBoardHasFewMatches3OrMoreOfTheSameBlocksInTheColumnMatches_True(uint[,] board)
        {
            //arrange
            var pattern = new Match3AndMoreInHorizontalOrVerticalPattern();

            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsTrue(isMatched, "The board has at least one match in the column");
            //add additional asserts
        }

        //
        [Test]
        [TestCaseSource(nameof(BoardHasFewMatches3OrMoreOfTheSameBlocksInTheRowCases))]
        public void isMatched_WhenBoardHasFewMatches3OrMoreOfTheSameBlocksInTheRowMatches_True(uint[,] board)
        {
            //arrange
            var pattern = new Match3AndMoreInHorizontalOrVerticalPattern();

            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsTrue(isMatched, "The board has at least one match in the row");
            //add additional asserts
        }
        
        [Test]
        [TestCaseSource(nameof(BoardHasMoreThan3OfTheSameBlocksInTheRowCases))]
        public void isMatched_WhenBoardHasMoreThan3OfTheSameBlocksInTheRowMatch_True(uint[,] board)
        {
            //arrange
            var pattern = new Match3AndMoreInHorizontalOrVerticalPattern();

            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsTrue(isMatched, "The board has at least one match in the row");
            //add additional asserts
        }

        // naming test pattern "add_WithNegativeAndPositiveNumbers_ReturnsCorrectSum"
        [Test]
        public void isMatched_WhenBoardHasAllDifferentBlocks_False()
        {
            //arrange
            var pattern = new Match3AndMoreInHorizontalOrVerticalPattern();
            var board = new uint[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 6, 7 },
                { 9, 10, 11, 12 },
                { 13, 13, 15, 15 }
            };
            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsFalse(isMatched, "The board does not have matches");
        }

        [Test]
        [TestCaseSource(nameof(BoardHas3OfTheSameBlocksInTheRowCases))]
        public void isMatched_WhenBoardHasOne3OfTheSameBlocksInTheRowMatch_True(uint[,] board)
        {
            //arrange
            var pattern = new Match3AndMoreInHorizontalOrVerticalPattern();

            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsTrue(isMatched, "The board has at least one match in the row");
        }

        [Test]
        public void MethodName_Scenario_ExpectedBehavior()
        {
            //arrange
            //act
            //assert
        }
    }
}
