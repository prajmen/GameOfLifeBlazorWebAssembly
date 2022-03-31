using GameOfLifeBlazorWebAssembly.Models;

namespace GameOfLifeBlazorWebAssembly.Interfaces
{
    public interface IGame
    {
        int Rows { get; set; }
        int Columns { get; set; }

        Cell[,] GameState { get; set; }

        Cell[,] NewGame(int rows, int columns);

        Cell[,] ReturnNewState();

        Cell[,] PaintCell((int, int) coordinates);
        Cell[,] ClearState();

    }
}
