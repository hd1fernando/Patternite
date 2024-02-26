
public class Grid
{
    public int[,] _matrix { get; private set; }


    private Grid(int rows, int cols)
    {
        _matrix = new int[rows, cols];
    }


    public static Grid Create(int rows, int cols)
        => new Grid(rows, cols);

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

}