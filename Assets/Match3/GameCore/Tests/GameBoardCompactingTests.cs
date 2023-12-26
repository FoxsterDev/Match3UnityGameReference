using System.Collections.Generic;
using NUnit.Framework;

namespace Match3.GameCore.Tests
{
    public class GameBoardCompactingTests
    {
        public static IEnumerable<TestDataWrapper<uint[,], uint[,]>> BoardHasCompactingInOnlyOneColumnTestCases()
        {
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 4 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 4 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 1 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 4 },
                    { 13, 14, 15, 1 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 4 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 1 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 4 },
                    { 13, 14, 15, 1 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 3 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 3 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 4 },
                    { 13, 14, 15, 3 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 4 },
                    { 9, 10, 1, 3 },
                    { 13, 14, 15, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 4 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 3 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 4 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 3 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 4 },
                    { 13, 14, 15, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 3 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 3 },
                    { 13, 14, 15, 3 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 4 },
                    { 13, 14, 15, 3 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 0 },
                    { 13, 14, 15, 3 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 0 },
                    { 13, 14, 15, 4 },
                    { 13, 14, 15, 3 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 3 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 4 },
                    { 9, 10, 1, 3 },
                    { 13, 14, 15, 2 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 3, 2 },
                    { 0, 10, 1, 5 },
                    { 0, 14, 15, 6 }
                },
                Expected = new uint[,]
                {
                    { 0, 2, 3, 4 },
                    { 0, 2, 3, 2 },
                    { 1, 10, 1, 5 },
                    { 1, 14, 15, 6 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 0, 2, 3, 2 },
                    { 0, 10, 1, 5 },
                    { 0, 14, 15, 6 }
                },
                Expected = new uint[,]
                {
                    { 0, 2, 3, 4 },
                    { 0, 2, 3, 2 },
                    { 0, 10, 1, 5 },
                    { 1, 14, 15, 6 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 0, 2, 3, 4 },
                    { 1, 2, 3, 2 },
                    { 0, 10, 1, 5 },
                    { 0, 14, 15, 6 }
                },
                Expected = new uint[,]
                {
                    { 0, 2, 3, 4 },
                    { 0, 2, 3, 2 },
                    { 0, 10, 1, 5 },
                    { 1, 14, 15, 6 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 2, 2, 3, 4 },
                    { 1, 2, 3, 2 },
                    { 0, 10, 1, 5 },
                    { 0, 14, 15, 6 }
                },
                Expected = new uint[,]
                {
                    { 0, 2, 3, 4 },
                    { 0, 2, 3, 2 },
                    { 2, 10, 1, 5 },
                    { 1, 14, 15, 6 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 0, 2, 3, 2 },
                    { 2, 10, 1, 5 },
                    { 0, 14, 15, 6 }
                },
                Expected = new uint[,]
                {
                    { 0, 2, 3, 4 },
                    { 0, 2, 3, 2 },
                    { 1, 10, 1, 5 },
                    { 2, 14, 15, 6 }
                }
            };
        }

        public static IEnumerable<TestDataWrapper<uint[,], uint[,]>> BoardHasFewCompactingTestCases()
        {
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 0, 0 },
                    { 9, 10, 0, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 2, 0, 0 },
                    { 1, 2, 0, 0 },
                    { 9, 10, 3, 0 },
                    { 13, 14, 15, 4 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 0, 3, 4 },
                    { 1, 2, 0, 0 },
                    { 9, 0, 0, 0 },
                    { 13, 0, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 1, 0, 0, 0 },
                    { 1, 0, 0, 0 },
                    { 9, 0, 3, 0 },
                    { 13, 2, 15, 4 }
                }
            };
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value = new uint[,]
                {
                    { 1, 0, 3, 4 },
                    { 1, 2, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 15, 0 }
                },
                Expected = new uint[,]
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 1, 0, 3, 0 },
                    { 1, 2, 15, 4 }
                }
            };
        }

        public static IEnumerable<TestDataWrapper<uint[,], List<(int startRow, int startColumn, int targetRow, int targetColumn)>>>
            BoardHasShiftsInOneColumnTestCases()
        {
            yield return new TestDataWrapper<uint[,], List<(int startRow, int startColumn, int targetRow, int targetColumn)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 2, 0 },
                    { 9, 10, 5, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new List<(int startRow, int startColumn, int targetRow, int targetColumn)>
                {
                    (0, 3, 3, 3)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int startRow, int startColumn, int targetRow, int targetColumn)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 2, 4 },
                    { 9, 10, 5, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new List<(int startRow, int startColumn, int targetRow, int targetColumn)>
                {
                    (1, 3, 3, 3)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int startRow, int startColumn, int targetRow, int targetColumn)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 2, 0 },
                    { 9, 10, 5, 4 },
                    { 13, 14, 15, 0 }
                },
                Expected = new List<(int startRow, int startColumn, int targetRow, int targetColumn)>
                {
                    (2, 3, 3, 3)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int startRow, int startColumn, int targetRow, int targetColumn)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 2, 3 },
                    { 9, 10, 5, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new List<(int startRow, int startColumn, int targetRow, int targetColumn)>
                {
                    (1, 3, 3, 3),
                    (0, 3, 2, 3)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int startRow, int startColumn, int targetRow, int targetColumn)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 4 },
                    { 1, 2, 2, 3 },
                    { 9, 0, 5, 0 },
                    { 13, 14, 15, 0 }
                },
                Expected = new List<(int startRow, int startColumn, int targetRow, int targetColumn)>
                {
                    (1, 3, 3, 3),
                    (0, 3, 2, 3),
                    (1, 1, 2, 1),
                    (0, 1, 1, 1)
                }
            };
        }

        [TestCaseSource(nameof(BoardHasShiftsInOneColumnTestCases))]
        public void isCompacted_WhenBoardHasShiftsInOneColumn_True(
            TestDataWrapper<uint[,], List<(int startRow, int startColumn, int targetRow, int targetColumn)>> td)
        {
            //arrange
            var compacting = new GameBoardCompacting();
            //act
            compacting.Compact(td.Value, out var shifts, out var outBoard);
            //assert
            Assert.IsTrue(IsShiftsEqual(shifts, td.Expected), "After compacting expected shifts are not equal");
        }

        static bool IsShiftsEqual(List<(int startRow, int startColumn, int targetRow, int targetColumn)> source,
                                  List<(int startRow, int startColumn, int targetRow, int targetColumn)> target)
        {
            var count = source.Count;
            var count2 = target.Count;
            if (count != count2)
            {
                return false;
            }

            for (var index = 0; index < source.Count; index++)
            {
                var it = source[index];
                var it2 = target[index];

                if (it.startRow != it2.startRow ||
                    it.startColumn != it2.startColumn ||
                    it.targetRow != it2.targetRow ||
                    it.targetColumn != it2.targetColumn)
                {
                    return false;
                }
            }

            return true;
        }

        [TestCaseSource(nameof(BoardHasFewCompactingTestCases))]
        public void isCompacted_WhenBoardHasFewCompacting_True(TestDataWrapper<uint[,], uint[,]> td)
        {
            //arrange
            ICompacting compacting = new GameBoardCompacting();
            //act
            compacting.Compact(td.Value, out var shifts, out var outBoard);
            //assert
            Assert.IsTrue(outBoard.IsEqualBoardTo(td.Expected), $"After compacting expected board does not equal to out board\n{outBoard.ConvertToString()}");
        }

        [TestCaseSource(nameof(BoardHasCompactingInOnlyOneColumnTestCases))]
        public void isCompacted_WhenBoardHasCompactingInOnlyOneColumn_True(TestDataWrapper<uint[,], uint[,]> td)
        {
            //arrange
            ICompacting compacting = new GameBoardCompacting();
            //act
            compacting.Compact(td.Value, out var shifts, out var outBoard);
            //assert
            Assert.IsTrue(outBoard.IsEqualBoardTo(td.Expected), $"After compacting expected board does not equal to out board\n{outBoard.ConvertToString()}");
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
