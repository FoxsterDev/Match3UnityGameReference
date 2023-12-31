using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Match3.GameCore.Tests
{
    public class Match3OrMoreOfTheSameBlocksPatternTests
    {
        public static object[] BoardDoesNotHaveMatches3OrMoreTestCases =
        {
            new uint[,]
            {
                { 1, 0, 0, 1 },
                { 1, 2, 3, 0 },
                { 9, 10, 0, 0 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 0, 2, 3, 4, 5 },
                { 2, 10, 11, 12, 13 },
                { 0, 14, 0, 2, 0 }
            },
            new uint[,]
            {
                { 0, 2, 0 },
                { 0, 1, 1 },
                { 1, 2, 1 }
            },
            new uint[,]
            {
                { 2, 1, 2, 3, 25 },
                { 5, 0, 3, 0, 6 },
                { 10, 11, 0, 4, 0 },
                { 13, 14, 0, 16, 16 }
            }
        };

        public static object[] BoardHasOnlyEmptyBlockMatchesCases =
        {
            new uint[,]
            {
                { 1, 0, 0, 0 },
                { 1, 2, 3, 0 },
                { 9, 10, 0, 0 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 0, 2, 3, 4, 5 },
                { 0, 10, 11, 12, 13 },
                { 0, 14, 0, 0, 0 }
            },
            new uint[,]
            {
                { 0, 0, 0 },
                { 0, 1, 1 },
                { 1, 2, 1 }
            },
            new uint[,]
            {
                { 2, 1, 2, 3, 25 },
                { 5, 0, 0, 0, 6 },
                { 10, 11, 0, 0, 0 },
                { 13, 14, 0, 16, 16 }
            }
        };

        public static object[] BoardHasFewMatches3OrMoreOfTheSameBlocksWithEmptyBlocksInTheRowCases =
        {
            new uint[,]
            {
                { 1, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 9, 10, 0, 0 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 3, 6, 6, 6, 6 },
                { 9, 10, 11, 12, 13 },
                { 13, 14, 0, 0, 0 }
            },
            new uint[,]
            {
                { 0, 0, 0 },
                { 0, 1, 1 },
                { 1, 1, 1 }
            },
            new uint[,]
            {
                { 2, 1, 1, 1, 25 },
                { 5, 6, 6, 6, 6 },
                { 10, 11, 0, 0, 0 },
                { 13, 14, 16, 16, 16 }
            }
        };

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
                { 13, 14, 15, 15, 15 }
            },
            new uint[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            },
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
                { 13, 14, 15, 16, 16 }
            },
            new uint[,]
            {
                { 2, 1, 1, 2, 25 },
                { 5, 6, 6, 6, 6 },
                { 10, 10, 10, 10, 10 },
                { 13, 14, 15, 16, 16 }
            },
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
                { 1, 1, 1 }
            },
            new uint[,]
            {
                { 4, 1, 1, 1 }
            },
            new uint[,]
            {
                { 1, 1, 1, 4 }
            },
            new uint[,]
            {
                { 5, 1, 1, 1, 4 }
            },
            new uint[,]
            {
                { 5, 1, 1, 1, 1, 4 }
            },
            new uint[,]
            {
                { 1, 1, 1, 4 },
                { 5, 6, 7, 8 }
            },
            new uint[,]
            {
                { 1, 1, 1, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 1, 1, 1, 4 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 1, 1, 1, 4 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 1, 1, 1, 4 }
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
                { 5, 6, 7, 8 },
                { 2, 1, 1, 1 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 2, 1, 1, 1 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 },
                { 2, 1, 1, 1 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8, 2 },
                { 9, 10, 11, 12, 2 },
                { 13, 14, 15, 16, 2 },
                { 2, 1, 1, 1, 2 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8, 2 },
                { 9, 10, 11, 12, 2 },
                { 2, 1, 1, 1, 2 },
                { 13, 14, 15, 16, 2 }
            },
            new uint[,]
            {
                { 5, 6, 7, 8, 2 },
                { 2, 1, 1, 1, 2 },
                { 9, 10, 11, 12, 2 },
                { 13, 14, 15, 16, 2 }
            },
            new uint[,]
            {
                { 2, 1, 1, 1, 2 },
                { 5, 6, 7, 8, 2 },
                { 9, 10, 11, 12, 2 },
                { 13, 14, 15, 16, 2 }
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
                { 3, 4 },
                { 1, 5 },
                { 1, 6 },
                { 1, 7 }
            },
            new uint[,]
            {
                { 3 },
                { 1 },
                { 1 },
                { 1 }
            },
            new uint[,]
            {
                { 1 },
                { 1 },
                { 1 }
            },
            new uint[,]
            {
                { 1 },
                { 1 },
                { 1 },
                { 3 }
            },
            new uint[,]
            {
                { 3 },
                { 1 },
                { 1 },
                { 1 },
                { 3 }
            },
            new uint[,]
            {
                { 1, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 1, 10, 11, 12 },
                { 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 3, 1, 2, 3, 4 },
                { 4, 1, 6, 7, 8 },
                { 5, 1, 10, 11, 12 },
                { 6, 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 7, 3, 1, 2, 3, 4 },
                { 8, 4, 1, 6, 7, 8 },
                { 9, 5, 1, 10, 11, 12 },
                { 9, 6, 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 7, 3, 1, 2, 3, 4 },
                { 2, 8, 4, 1, 6, 7, 8 },
                { 3, 9, 5, 1, 10, 11, 12 },
                { 4, 9, 6, 13, 14, 15, 16 }
            },
            new uint[,]
            {
                { 1, 7, 3, 1, 2, 3 },
                { 2, 8, 4, 1, 6, 7 },
                { 3, 9, 5, 1, 10, 11 },
                { 4, 9, 6, 13, 14, 15 }
            },
            new uint[,]
            {
                { 1, 7, 3, 1, 2 },
                { 2, 8, 4, 1, 6 },
                { 3, 9, 5, 1, 10 },
                { 4, 9, 6, 13, 14 }
            },
            new uint[,]
            {
                { 1, 7, 3, 1 },
                { 2, 8, 4, 1 },
                { 3, 9, 5, 1 },
                { 4, 9, 6, 13 }
            },
            new uint[,]
            {
                { 4, 9, 6, 13 },
                { 1, 7, 3, 1 },
                { 2, 8, 4, 1 },
                { 3, 9, 5, 1 },
                { 4, 9, 6, 13 }
            },
            new uint[,]
            {
                { 4, 9, 6, 13 },
                { 1, 7, 3, 1 },
                { 2, 8, 4, 1 },
                { 3, 9, 5, 1 }
            },
            new uint[,]
            {
                { 4, 9, 3, 4 },
                { 1, 7, 1, 5 },
                { 2, 8, 1, 6 },
                { 3, 9, 1, 7 }
            },
            new uint[,]
            {
                { 4, 3, 4 },
                { 1, 1, 5 },
                { 2, 1, 6 },
                { 3, 1, 7 }
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

        public static IEnumerable<TestDataWrapper<uint[,], List<(int row, int column, uint id)>>> BoardHasTheOneMatchInTheColumnTestCases()
        {
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 2 },
                    { 1, 2, 3, 1 },
                    { 1, 10, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (0, 0, 1),
                    (1, 0, 1),
                    (2, 0, 1)
                }
            };
        }

        public static IEnumerable<TestDataWrapper<uint[,], List<(int row, int column, uint id)>>> BoardHasTheOneMatchInTheRowTestCases()
        {
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 1, 1, 2 },
                    { 1, 2, 3, 1 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (0, 0, 1),
                    (0, 1, 1),
                    (0, 2, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 1 },
                    { 1, 1, 1, 2 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (1, 0, 1),
                    (1, 1, 1),
                    (1, 2, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 1 },
                    { 9, 10, 1, 2 },
                    { 1, 1, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (2, 0, 1),
                    (2, 1, 1),
                    (2, 2, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 1 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 4 },
                    { 1, 1, 1, 2 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (3, 0, 1),
                    (3, 1, 1),
                    (3, 2, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 3, 2, 3, 1 },
                    { 2, 9, 10, 1 },
                    { 1, 3, 14, 15 },
                    { 2, 1, 1, 1 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (3, 1, 1),
                    (3, 2, 1),
                    (3, 3, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 3, 2, 3, 1 },
                    { 2, 9, 10, 1 },
                    { 2, 1, 1, 1 },
                    { 1, 3, 14, 15 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (2, 1, 1),
                    (2, 2, 1),
                    (2, 3, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 3, 2, 3, 1 },
                    { 2, 1, 1, 1 },
                    { 2, 9, 10, 1 },
                    { 1, 3, 14, 15 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (1, 1, 1),
                    (1, 2, 1),
                    (1, 3, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 2, 1, 1, 1 },
                    { 3, 2, 3, 1 },
                    { 2, 9, 10, 1 },
                    { 1, 3, 14, 15 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (0, 1, 1),
                    (0, 2, 1),
                    (0, 3, 1)
                }
            };
        }

        [Test]
        [TestCaseSource(nameof(BoardHasTheOneMatchInTheRowTestCases))]
        public void isMatched_WhenBoardHasTheOneMatchInTheRowTestCases_True(TestDataWrapper<uint[,], List<(int row, int column, uint id)>> td)
        {
            //arrange
            uint matchCount = 3;
            var combinationsCount = 1;
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern(matchCount, PatternOperator.Equal);

            //act
            var isMatched = pattern.IsMatched(td.Value, out var matchesInTheRow, out var matchesInTheColumn);

            Assert.That(isMatched, Is.True, "The board does not have matches");
            Assert.That(matchesInTheRow.Count , Is.EqualTo(combinationsCount), "Combinations count is wrong");

            var match = matchesInTheRow[0];
            Assert.IsTrue(match[0].column < match[1].column && match[1].column < match[2].column, "column is not sorted");
            Assert.IsTrue(match[0].row == match[1].row && match[1].row == match[2].row, "row is different");

            Assert.IsTrue(match.Count == td.Expected.Count && !match.Except(td.Expected).Any(), "Expected match is not the same from pattern checks");
        }

        [Test]
        [TestCaseSource(nameof(BoardDoesNotHaveMatches3OrMoreTestCases))]
        public void isMatched_WhenBoardDoesNotHaveMatchesCases_False(uint[,] board)
        {
            //arrange
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();

            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsFalse(isMatched, "The board does not have 3 or more matches");
            //add additional asserts
        }

        //
        [Test]
        [TestCaseSource(nameof(BoardHasOnlyEmptyBlockMatchesCases))]
        public void isMatched_WhenBoardHasOnlyEmptyBlockMatchesCases_False(uint[,] board)
        {
            //arrange
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();

            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsFalse(isMatched, "The board has only empty blocks");
            //add additional asserts
        }

        [Test]
        [TestCaseSource(nameof(BoardHasFewMatches3OrMoreOfTheSameBlocksWithEmptyBlocksInTheRowCases))]
        public void isMatched_WhenBoardHasFewMatches3OrMoreOfTheSameBlocksWithEmptyBlocksInTheRow_True(uint[,] board)
        {
            //arrange
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();

            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsTrue(isMatched, "The board has at least one match in the row");
            //add additional asserts
        }

        [Test]
        [TestCaseSource(nameof(BoardHas3OfTheSameBlocksInTheColumnCases))]
        public void isMatched_WhenBoardHasFewMatches3OrMoreOfTheSameBlocksInTheColumnMatches_True(uint[,] board)
        {
            //arrange
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();

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
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();

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
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();

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
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();
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
            var pattern = new MatchSomeCountInHorizontalOrVerticalPattern();

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
