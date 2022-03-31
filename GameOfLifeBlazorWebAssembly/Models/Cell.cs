namespace GameOfLifeBlazorWebAssembly.Models
{
    public class Cell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsDead { get; set; }
        public bool IsGonnaDie { get; set; }
        public HashSet<Cell> Neighbours { get; set; }
        public int NeighboursActiveCount { get; set; }

        public Cell(int row, int column, bool isDead = true)
        {
            Row = row;
            Column = column;
            IsDead = isDead;
            Neighbours = new HashSet<Cell>();

            int rng = Random.Shared.Next(1, 3);

            if (rng == 1)
            {
                IsDead = true;
            }
            else
            {
                IsDead = false;
            }
        }


        public void CheckStatus()
        {
            foreach (var cell in Neighbours)
            {
                if (cell.IsDead == false)
                {
                    NeighboursActiveCount++;
                }
            }

            if (IsDead == true)
            {
                if (NeighboursActiveCount == 3)
                {
                    IsGonnaDie = false;
                }
                else
                {
                    IsGonnaDie = true;
                }
            }
            else
            {
                if (NeighboursActiveCount < 2 || NeighboursActiveCount > 3)
                {
                    IsGonnaDie = true;
                }
                else
                {
                    IsGonnaDie = false;
                }
            }

            NeighboursActiveCount = 0;
        }
    }
}
