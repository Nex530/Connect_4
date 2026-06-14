using System.Numerics;

namespace Connect_4
{
    internal class Program
    {
        static void Print(char[][] matrix)
        {
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.Write(matrix[j][k] + " ");
                }
                Console.WriteLine();
            }
        }
        static int getFreeRowNum(char[][] matrix, int columns)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (matrix[i][columns-1] == '_')
                {
                    return i;
                }
            }
            return 0;
        }

        static bool xWins(char[][]matrix)
        {
            // checking rows
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix[i][j] == 'x' && matrix[i][j+1] == 'x' && matrix[i][j + 2] == 'x' && matrix[i][j + 3] == 'x')
                    {
                        return true;
                    }
                }
            }

            // checking columns
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    if (matrix[i][j] == 'x' && matrix[i + 1][j] == 'x' && matrix[i + 2][j] == 'x' && matrix[i + 3][j] == 'x')
                    {
                        return true;
                    }
                }
            }



            return false;
        }
        static bool oWins(char[][] matrix)
        {
            // checking rows
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix[i][j] == 'o' && matrix[i][j + 1] == 'o' && matrix[i][j + 2] == 'o' && matrix[i][j + 3] == 'o')
                    {
                        return true;
                    }
                }
            }
            // checking columns
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    if (matrix[i][j] == 'o' && matrix[i + 1][j] == 'o' && matrix[i + 2][j] == 'o' && matrix[i + 3][j] == 'o')
                    {
                        return true;
                    }
                }
            }



            return false;
        }


        static bool submatrixDiagWinX(char[][] submatrix) 
        {
            return (submatrix[0][0] == 'x' && submatrix[1][1] == 'x' && submatrix[2][2] == 'x' && submatrix[3][3] == 'x') ||
                (submatrix[0][3] == 'x' && submatrix[1][2] == 'x' && submatrix[2][1] == 'x' && submatrix[3][0] == 'x'); 
        }
        static bool submatrixDiagWinO(char[][] submatrix)
        {
            return (submatrix[0][0] == 'o' && submatrix[1][1] == 'o' && submatrix[2][2] == 'o' && submatrix[3][3] == 'o') ||
                (submatrix[0][3] == 'o' && submatrix[1][2] == 'o' && submatrix[2][1] == 'o' && submatrix[3][0] == 'o');
        }

        static void Main(string[] args)
        {
            char[][] matrix = [['_', '_', '_', '_', '_', '_', '_'],
                               ['_', '_', '_', '_', '_', '_', '_'],
                               ['_', '_', '_', '_', '_', '_', '_'],
                               ['_', '_', '_', '_', '_', '_', '_'],
                               ['_', '_', '_', '_', '_', '_', '_'],
                               ['_', '_', '_', '_', '_', '_', '_']];
            for (int i = 0; i < 42; i++)
            {
                Console.WriteLine("Enter row number and column number: ");
                int columns = int.Parse(Console.ReadLine());
                bool correctInput = false;
                if (1 <= columns && columns <= 7 && matrix[0][columns - 1] == '_')
                {
                    Console.WriteLine("You can put a symbol there.");
                    correctInput = true;
                }
                else
                {
                    Console.WriteLine("Spot unavailable.");
                    i--;
                }
                
                if (i % 2 == 0 && correctInput)
                {
                    int row = getFreeRowNum(matrix, columns);
                    matrix[row][columns - 1] = 'x';
                }
                else if (i % 2 == 1 && correctInput)
                {
                    int row = getFreeRowNum(matrix, columns);
                    if (matrix[row][columns - 1] == '_')
                    {
                        matrix[row][columns - 1] = 'o';
                    }
                    else
                    {
                        Console.WriteLine("Spot unavailable.");
                        i--;
                    }
                }
                Print(matrix);

                if (xWins(matrix) ) { Console.WriteLine("X wins."); break; }
            }
            for ( )
        }
    }
}
