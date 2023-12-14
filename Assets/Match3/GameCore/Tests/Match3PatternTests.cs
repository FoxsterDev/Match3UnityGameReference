using NUnit.Framework;

namespace Match3.GameCore.Tests
{
    public class Match3PatternTests
    {
        // naming test pattern "add_WithNegativeAndPositiveNumbers_ReturnsCorrectSum"
        [Test]
        public void isMatched_WhenBoardHasAllDifferentBlocks_False()
        {
            //arrange
            var pattern = new Match3AndMoreInHorizontalOrVerticalPattern();
            var board = new uint[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12},
                { 13, 14, 15, 16}
            };
            //act
            var isMatched = pattern.IsMatched(board);

            //assert
            Assert.IsFalse(isMatched, "The board does not have matches");
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
