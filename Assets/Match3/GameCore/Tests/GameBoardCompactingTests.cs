using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Match3.GameCore.Tests
{
    public class GameBoardCompactingTests
    {
        
        public static IEnumerable<TestDataWrapper<uint[,], uint[,]>> BoardHasOnlyOneCompactingTestCases()
        {
            yield return new TestDataWrapper<uint[,], uint[,]>
            {
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
                Value =  new uint[,]
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
        }

        public class TestDataWrapper<T, TExp>
        {
            public T? Value { get; set; }
            public TExp? Expected { get; set; }
        }

        [TestCaseSource(nameof(BoardHasOnlyOneCompactingTestCases))]
        public void isMatched_WhenBoardHasOnlyOneCompacting_True(TestDataWrapper<uint[,], uint[,]> td)
        {
            //arrange
            var compacting = new GameBoardCompacting();
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
