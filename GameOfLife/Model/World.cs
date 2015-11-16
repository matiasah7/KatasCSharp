using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Model
{
    public class World
    {
        public List<Position> CellsList {get; private set;}

        public World()
        {
            CellsList = new List<Position>();
        }

        public void AddCellAtPosition(Position position)
        {
            CellsList.Add(position);
        }

        public bool IsCellAliveAtPosition(Position position)
        {
            return CellsList.Contains(position);
        }

        public void Refresh()
        {
            ReviveCells();
            RemoveCellsThatShouldDie();
        }

        private void ReviveCells()
        {
            CellsList.AddRange(ReviveCellsList());
        }

        private IEnumerable<Position> ReviveCellsList()
        {
            var reviveCellsList = new List<Position>();
            foreach (var position in CellsList.Where(ShouldCheckRevive).ToList()) reviveCellsList.AddRange(ReviveNeighboursOf(position));
            return reviveCellsList;
        }

        private IEnumerable<Position> ReviveNeighboursOf(Position position)
        {
            var neighbours = new List<Position>();
            for (var i = position.X - 1; i <= position.X + 1; i++)
            {
                for (var j = position.Y - 1; j <= position.Y + 1; j++)
                {
                    if (CellShouldRevive(new Position(i,j))) neighbours.Add(new Position(i, j));
                }
            }
            return neighbours;
        }

        private bool CellShouldRevive(Position position)
        {
            return !this.IsCellAliveAtPosition(position) && this.GetNumberOfNeighboursOf(position) == 3;
        }

        private bool ShouldCheckRevive(Position position)
        {
            return GetNumberOfNeighboursOf(position) == 2;
        }

        private void RemoveCellsThatShouldDie()
        {
            foreach (var position in ShouldDieCellsList()) CellsList.Remove(position);
        }

        private IEnumerable<Position> ShouldDieCellsList()
        {
            return CellsList.ToList().Where(ShouldDie).ToList();
        }

        private bool ShouldDie(Position position)
        {
            var numberOfNeighbours = this.GetNumberOfNeighboursOf(position);
            return numberOfNeighbours < 2 || numberOfNeighbours >= 4;
        }

        private int GetNumberOfNeighboursOf(Position position)
        {
            var neighbours = 0;
            for (var i = position.X-1; i <= position.X+1 ; i++)
            {
                for (var j = position.Y-1; j <= position.Y+1 ; j++)
                {
                    if (IsNeighbour(position, new Position(i,j))) neighbours++;
                }
            }
            return neighbours;
        }

        private bool IsNeighbour(Position position, Position neighbourPosition)
        {
            return this.IsCellAliveAtPosition(neighbourPosition) && !position.Equals(neighbourPosition);
        }

        public List<Position> GetNeighbours(Position position)
        {
            var neighboursList = new List<Position>();
            for (var i = position.X - 1; i <= position.X + 1; i++)
            {
                for (var j = position.Y - 1; j <= position.Y + 1; j++)
                {
                    if (this.IsCellAliveAtPosition(new Position(i, j))) neighboursList.Add(new Position(i,j));
                }
            }
            neighboursList.Remove(position);
            return neighboursList;
        }
    }
}