
public class Grid<T>
{
    private T[,] _matrix { get; set; }


    public Grid(int rows, int cols)
    {
        _matrix = new T[rows, cols];
    }

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

    public void Pupulate(Func<T> func)
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                _matrix[i, j] = func();
            }
        }
    }

    public int Rows => _matrix.GetLength(0);
    public int Cols => _matrix.GetLength(1);

    public T this[int row, int col]
    {
        get => _matrix[row, col];
        set => _matrix[row, col] = value;
    }

    public Grid<T> Clone()
    {
        return new Grid<T>(_matrix.GetLength(0), _matrix.GetLength(1))
        {
            _matrix = (T[,])_matrix.Clone()
        };
    }

}