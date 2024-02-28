

using System.Runtime.CompilerServices;

int size = 50;
var grid = new Grid<Cell>(size, size);
grid.Pupulate(() => Cell.DeadCell);
var game = new GameOfLife(grid);
game.GliderPopulation();
game.Run(500);

public sealed class GameOfLife
{
    private Grid<Cell> _grid { get; set; }

    public GameOfLife(Grid<Cell> grid)
    {
        _grid = grid;
    }


    public void GliderPopulation()
    {
        _grid[2, 2] = Cell.LiveCell;
        _grid[3, 3] = Cell.LiveCell;
        _grid[3, 4] = Cell.LiveCell;
        _grid[4, 2] = Cell.LiveCell;
        _grid[4, 3] = Cell.LiveCell;
    }

    private int NumsOfLivedNeighbors(int row, int col)
    {
        int result = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int localRow = (row + i + _grid.Rows) % _grid.Rows;
                int localCol = (col + j + _grid.Cols) % _grid.Cols;

                if (_grid[localRow, localCol] == Cell.LiveCell)
                {
                    result++;
                }
            }
        }

        if (_grid[row, col] == Cell.LiveCell)
        {
            result--;
        }

        return result;
    }


    public void Run(int msSleep)
    {
        var tempGrid = _grid.Clone();
        _grid.Print();

        while (true)
        {
            ClearScreen();
            for (int i = 0; i < _grid.Rows; i++)
            {
                for (int j = 0; j < _grid.Cols; j++)
                {
                    int livedNeighbors = NumsOfLivedNeighbors(i, j);
                    bool livedCellShouldDie = _grid[i, j] == Cell.LiveCell && (livedNeighbors < 2 || livedNeighbors > 3);
                    if (livedCellShouldDie)
                    {
                        tempGrid[i, j] = Cell.DeadCell;
                        continue;
                    }

                    bool deadCellShouldLive = _grid[i, j] == Cell.DeadCell && livedNeighbors == 3;
                    if (deadCellShouldLive)
                    {
                        tempGrid[i, j] = Cell.LiveCell;
                        continue;
                    }
                }
            }

            _grid = tempGrid.Clone();
            _grid.Print();

            Thread.Sleep(msSleep);
        }

    }

    private void ClearScreen()
    {
        Console.Clear();
    }

}

public sealed class Cell
{
    public string? Value { get; private set; }

    private Cell(string? value)
    {
        Value = value;
    }

    public static Cell LiveCell => new Cell("*");
    public static Cell DeadCell => new Cell(".");

    public static bool operator ==(Cell cell, Cell other) => cell.Value == other.Value;
    public static bool operator !=(Cell cell, Cell other) => cell.Value != other.Value;

    public override string ToString() => Value!;

    public Cell Clone() => new Cell(Value);

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        return (obj as Cell)?.Value == Value;
    }
}