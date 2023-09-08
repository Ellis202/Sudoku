using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sudoku = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = 0;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine("Ingresa el número para la fila " + (i + 1) + " y la columna " + (j + 1) + ":");
                    int num = int.Parse(Console.ReadLine());
                    while (!ValidarNumero(sudoku, i, j, num))
                    {
                        Console.WriteLine("Número inválido. Ingresa otro número:");
                        num = int.Parse(Console.ReadLine());
                    }
                    sudoku[i, j] = num;
                }
            }
            Console.WriteLine("Felicidades, Ganaste :D");
            Console.ReadKey();
        }

        private static bool ValidarNumero(int[,] sudoku, int fila, int columna, int numero)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[fila, i] == numero || sudoku[i, columna] == numero)
                {
                    return false;
                }
            }

            int subcuadriculaFila = (fila / 3) * 3;
            int subcuadriculaColumna = (columna / 3) * 3;

            for (int i = subcuadriculaFila; i < subcuadriculaFila + 3; i++)
            {
                for (int j = subcuadriculaColumna; j < subcuadriculaColumna + 3; j++)
                {
                    if (sudoku[i, j] == numero)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
