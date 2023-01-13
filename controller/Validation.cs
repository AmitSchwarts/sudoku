using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.controller
{
    internal class Validation
    {
        public static bool check_size(string input)
        {
            double size = Math.Sqrt(input.Length);
            return size % 1 == 0 && size > 0 && size < 26;
        }

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
