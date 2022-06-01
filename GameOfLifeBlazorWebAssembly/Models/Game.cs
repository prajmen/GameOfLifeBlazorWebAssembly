using GameOfLifeBlazorWebAssembly.Interfaces;

namespace GameOfLifeBlazorWebAssembly.Models
{
    public class Game : IGame
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Cell[,] GameState { get; set; } = null!;


        public Cell[,] PaintCell((int, int) coordinates)
        {
            var cell = GameState[coordinates.Item1, coordinates.Item2];

            if (cell.IsDead)
            {
                cell.IsDead = false;
            }
            else
            {
                cell.IsDead = true;
            }

            return GameState;
        }

        public Cell[,] ClearState()
        {
            foreach (var cell in GameState)
            {
                cell.IsDead = true;
            }

            return GameState;
        }

        public Cell[,] NewGame(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            GameState = GenerateCells(rows, columns);
            GenerateNeighbours(GameState);

            return GameState;
        }

        public Cell[,] ReturnNewState()
        {
            GenerateNewGeneration(GameState);

            return GameState;
        }

        private static Cell[,] GenerateCells(int rows, int columns)
        {
            var gameState = new Cell[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameState[i, j] = new Cell(i, j);

                }
            }

            return gameState;
        }

        private void GenerateNeighbours(Cell[,] gameState)
        {
            foreach (var cell in gameState)
            {
                for (int y = cell.Row - 1; y <= cell.Row + 1; y++)
                {
                    for (int x = cell.Column - 1; x <= cell.Column + 1; x++)
                    {
                        if (!(y == cell.Row && x == cell.Column))
                        {
                            int row = y;
                            int column = x;


                            if (y < 0)
                            {
                                row = Rows - 1;
                            }
                            if (x < 0)
                            {
                                column = Columns - 1;
                            }
                            if (y >= Rows)
                            {
                                row = 0;
                            }
                            if (x >= Columns)
                            {
                                column = 0;
                            }

                            cell.Neighbours.Add(gameState[row, column]);
                        }
                    }
                }
            }
        }


        private static void GenerateNewGeneration(Cell[,] gameState)
        {
            foreach (var cell in gameState)
            {
                cell.CheckStatus();
            }
            foreach (var cell in gameState)
            {
                cell.IsDead = cell.IsGonnaDie;
            }
        }
    }
}



