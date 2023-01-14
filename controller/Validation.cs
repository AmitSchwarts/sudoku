using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.controller
{
    internal class Validation
    {
        // gets a board string
        // checks if the size matches the settings,
        // meaning that the root will be int (requirement of every sudoku board)
        // and that the board size will be a minimum of 1 x 1 board and a maximum of 25 x 25 board (requirement of Sudoku Omega)
        // return if the board meets the requirements
        public static bool check_size(string input)
        {
            double size = Math.Sqrt(input.Length);
            return size % 1 == 0 && size > 0 && size < 26;
        }

        // gets a board string
        // check if its containe only chars that between one ans the max char the board can containe
        // return if the board  meets the requirements
        public static bool check_correct_chars(string input)
        {
            int size = Convert.ToInt32(Math.Sqrt(input.Length));
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '0' + size)
                    return false;
            }
            return true;
        }
    }
}
