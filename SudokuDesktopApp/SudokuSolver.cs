using System;
using System.Collections.Generic;

namespace MyForm
{
    public class SudokuSolver
    {
        public int[,] SodokuTable
        {
            get; set;
        }

        public SudokuSolver(int[,] inputTable)
        {
            SodokuTable = inputTable;
        }

        public bool Solve()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (SodokuTable[i, j] == 0)
                    {
                        return Possible(i, j);
                    }
                }
            }

            return true;
        }

        public bool Possible(int i, int j)
        {
            for (int number = 1; number <= 9; number++)
            {
                if (IsBlockPossible(i, j, number) && IsColumnPossible(i, number) && IsRowPossible(j, number))
                {
                    SodokuTable[i, j] = number;
                    if (Solve())
                    {
                        return true;
                    }
                }
            }

            SodokuTable[i, j] = 0;
            return false;
        }

        public bool IsColumnPossible(int column, int number)
        {
            for (int k = 0; k < 9; k++)
            {
                if (SodokuTable[column, k] == number)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowPossible(int row, int number)
        {
            for (int k = 0; k < 9; k++)
            {
                if (SodokuTable[k, row] == number)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsBlockPossible(int i, int j, int number)
        {
            int blockInitColumn = (i / 3) * 3;
            int blockInitRow = (j / 3) * 3;

            for (int m = blockInitColumn; m < blockInitColumn + 3; m++)
            {
                for (int n = blockInitRow; n < blockInitRow + 3; n++)
                {
                    if (SodokuTable[m, n] == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}