using System;
using System.Text;

class Matrix2D
{
    private int[,] matrix;
    private int rows;
    private int columns;

    public Matrix2D(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];
    }

    public int Rows => rows;
    public int Columns => columns;

    public int this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= rows || col < 0 || col >= columns)
            {
                throw new IndexOutOfRangeException("Недопустимий індекс");
            }
            return matrix[row, col];
        }
        set
        {
            if (row < 0 || row >= rows || col < 0 || col >= columns)
            {
                throw new IndexOutOfRangeException("Недопустимий індекс");
            }
            matrix[row, col] = value;
        }
    }

    public static Matrix2D operator +(Matrix2D matrix1, Matrix2D matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new InvalidOperationException("Матриці мають різний розмір");
        }

        Matrix2D result = new Matrix2D(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static Matrix2D operator -(Matrix2D matrix1, Matrix2D matrix2)
    {
        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new InvalidOperationException("Матриці мають різний розмір");
        }

        Matrix2D result = new Matrix2D(matrix1.Rows, matrix1.Columns);

        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public int SumOfElements()
    {
        int sum = 0;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                sum += this[i, j];
            }
        }

        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Matrix2D matrix1 = new Matrix2D(2, 2);
        matrix1[0, 0] = 1;
        matrix1[0, 1] = 2;
        matrix1[1, 0] = 3;
        matrix1[1, 1] = 4;

        Matrix2D matrix2 = new Matrix2D(2, 2);
        matrix2[0, 0] = 5;
        matrix2[0, 1] = 6;
        matrix2[1, 0] = 7;
        matrix2[1, 1] = 8;

        Matrix2D sum = matrix1 + matrix2;
        Matrix2D difference = matrix1 - matrix2;

        Console.WriteLine("Матриця 1:");
        PrintMatrix(matrix1);

        Console.WriteLine("\nМатриця 2:");
        PrintMatrix(matrix2);

        Console.WriteLine("\nСума матриць:");
        PrintMatrix(sum);

        Console.WriteLine("\nРізниця матриць:");
        PrintMatrix(difference);

        int sumMatrix1 = matrix1.SumOfElements();
        int sumMatrix2 = matrix2.SumOfElements();
        bool result = sumMatrix1 >= sumMatrix2;
        Console.WriteLine($"\nСума елементів матриці 1 {(result ? ">=" : "<")} Суми елементів матриці 2.");
    }

    static void PrintMatrix(Matrix2D matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
