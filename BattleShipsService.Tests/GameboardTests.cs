using System;
using NUnit.Framework;

namespace BattleShipsService.Tests
{
    [TestFixture]
    public class GameboardTests
    {
        [TestCase("a1", 0, 0)]
        [TestCase("b2", 1, 1)]
        [TestCase("i7", 6, 8)]
        [TestCase("i10", 9, 8)]
        [TestCase("A1", 0, 0)]
        [TestCase("B2", 1, 1)]
        [TestCase("I7", 6, 8)]
        [TestCase("I10", 9, 8)]
        public void TranslateCellReference_HandlesValidReferences(String cellReference, Int16 expectedRow, Int16 expectedColumn)
        {
            Assert.AreEqual(Gameboard.TranslateCellReference(cellReference, out Int16 row, out Int16 column), true);
            Assert.AreEqual(expectedRow, row);
            Assert.AreEqual(expectedColumn, column);
        }

        [TestCase("")]
        [TestCase("k1")]
        [TestCase("ak1")]
        [TestCase("a11")]
        [TestCase("a0")]
        public void TranslateCellReference_HandlesInvalidReferences(String cellReference)
        {
            Assert.AreEqual(Gameboard.TranslateCellReference(cellReference, out Int16 row, out Int16 column), false);
        }
    }
}