using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Match3.GameCore.Tests
{
    public class GameBoardBlocksGeneratorTests
    {
        public static IEnumerable<TestDataWrapper<uint[,], List<(int row, int column, uint id)>>> BoardBlocksGeneratorTestCases()
        {
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 2 },
                    { 1, 2, 3, 1 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>()
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 0, 3, 2 },
                    { 1, 2, 3, 1 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (0, 1, 1)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 1, 2, 3, 0 },
                    { 1, 2, 3, 0 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (1, 3, 1),
                    (0, 3, 2)
                }
            };
            yield return new TestDataWrapper<uint[,], List<(int row, int column, uint id)>>
            {
                Value = new uint[,]
                {
                    { 0, 0, 0, 0 },
                    { 1, 2, 3, 1 },
                    { 9, 10, 1, 2 },
                    { 13, 14, 15, 4 }
                },
                Expected = new List<(int row, int column, uint id)>
                {
                    (0, 3, 1),
                    (0, 2, 1),
                    (0, 1, 1),
                    (0, 0, 1)
                }
            };
        }

        [TestCaseSource(nameof(BoardBlocksGeneratorTestCases))]
        public void isFullfilled_WhenBoardHasEmptyBlocks_True(TestDataWrapper<uint[,], List<(int row, int column, uint id)>> td)
        {
            //arrange
            IBlocksGenerator generator = new GameBoardBlocksGenerator(1, 5);
            //act
            generator.Generate(td.Value, out var newBlocks, out var outBoard);
            //assert
            Assert.IsTrue(newBlocks.All(k => k.id > 0), "Some new blocks are empty");
            Assert.IsTrue(newBlocks.Count == td.Expected.Count, "Expected count of blocks is different to new blocks count");
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
