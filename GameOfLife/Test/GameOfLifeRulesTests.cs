using GameOfLife.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameOfLife.Test
{
    [TestClass]
    public class GameOfLifeRulesTests
    {
        private World _world;

        [TestInitialize]
        public void SetUp()
        {
            _world = new World();
        }

        [TestMethod]
        public void OneAloneCellIsAliveAfterAddeddTest()
        {
            _world.AddCellAtPosition(new Position(1, 1));
            Assert.IsTrue(_world.IsCellAliveAtPosition(new Position(1,1)));
        }

        [TestMethod]
        public void OneAloneCellDiedAfterRefreshTest()
        {
            _world.AddCellAtPosition(new Position(1, 1));
            _world.Refresh();
            Assert.IsTrue(!_world.IsCellAliveAtPosition(new Position(1, 1)));
        }

        [TestMethod]
        public void TwoNeighboursCellsAreAliveAfterAddedTest()
        {
            _world.AddCellAtPosition(new Position(1, 1));
            _world.AddCellAtPosition(new Position(2, 1));
            Assert.IsTrue(_world.IsCellAliveAtPosition(new Position(1, 1)));
            Assert.IsTrue(_world.IsCellAliveAtPosition(new Position(2, 1)));
        }
        [TestMethod]
        public void TwoNeighboursCellsDiedAfterRefreshTest()
        {
            _world.AddCellAtPosition(new Position(1, 1));
            _world.AddCellAtPosition(new Position(2, 1));
            _world.Refresh();
            Assert.IsTrue(!_world.IsCellAliveAtPosition(new Position(1, 1)));
            Assert.IsTrue(!_world.IsCellAliveAtPosition(new Position(2, 1)));
        }

        [TestMethod]
        public void ThreeCellsThatAreNeighboursStillAliveAfterRefreshTest()
        {
            _world.AddCellAtPosition(new Position(1, 1));
            _world.AddCellAtPosition(new Position(1, 2));
            _world.AddCellAtPosition(new Position(2, 1));
            _world.Refresh();
            Assert.IsTrue(_world.IsCellAliveAtPosition(new Position(1, 1)));
            Assert.IsTrue(_world.IsCellAliveAtPosition(new Position(1, 2)));
            Assert.IsTrue(_world.IsCellAliveAtPosition(new Position(2, 1)));
        }

        [TestMethod]
        public void CellWithFourNeighboursDieAfterRefreshTest()
        {
            _world.AddCellAtPosition(new Position(0, 0));
            _world.AddCellAtPosition(new Position(1, 1));
            _world.AddCellAtPosition(new Position(1, 2));
            _world.AddCellAtPosition(new Position(2, 1));
            _world.AddCellAtPosition(new Position(2, 2));
            _world.Refresh();
            Assert.IsTrue(!_world.IsCellAliveAtPosition(new Position(1, 1)));
        }

        [TestMethod]
        public void CellWithFiveNeighboursDieAfterRefreshTest()
        {
            _world.AddCellAtPosition(new Position(0, 0));
            _world.AddCellAtPosition(new Position(1, 0));
            _world.AddCellAtPosition(new Position(1, 1));
            _world.AddCellAtPosition(new Position(1, 2));
            _world.AddCellAtPosition(new Position(2, 1));
            _world.AddCellAtPosition(new Position(2, 2));
            _world.Refresh();
            Assert.IsTrue(!_world.IsCellAliveAtPosition(new Position(1, 1)));
        }

        [TestMethod]
        public void DiedCellWithThreeNeighboursReviveAfterRefreshTest()
        {
            _world.AddCellAtPosition(new Position(0, 1));
            _world.AddCellAtPosition(new Position(1, 0));
            _world.AddCellAtPosition(new Position(1, 1));
            _world.Refresh();
            Assert.IsTrue(_world.IsCellAliveAtPosition(new Position(0, 0)));
        }

        [TestMethod]
        public void NeighboursListOfCellTest()
        {
            _world.AddCellAtPosition(new Position(1, 1));
            _world.AddCellAtPosition(new Position(1, 2));
            _world.AddCellAtPosition(new Position(2, 1));
            Assert.IsTrue(_world.GetNeighbours(new Position(1,1)).Count == 2);
        }
    }
}
