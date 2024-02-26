
public class Grid<T>
{
    private T[,] _matrix { get; set; }


    public Grid(int rows, int cols)
    {
        _matrix = new T[rows, cols];
    }

    public static Grid<T> Create<T>(int rows, int cols)
        => new Grid<T>(rows, cols);

    public void Print()
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                Console.Write(_matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public T this[int row, int col]
    {
        get => _matrix[row, col];
        set => _matrix[row, col] = value;
    }

}