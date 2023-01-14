using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace sudoku.controller
{
    internal class Controller
    {
        // Holds a byte matrix of the sudoko string
        private byte[,] matrix;

        // Creating an object of type controller 
        public Controller(string text) 
        {
            matrix = StringToMatrix(text); // convert the string into a byte matrix and insert the result to matrix
        }

        public void tryToSolve()
        {

        }

        public byte[,] StringToMatrix(string text)
        {
            int size = Convert.ToInt32(Math.Sqrt(text.Length)); // size of the new matrix
            byte[,] matrix = new byte[size, size]; // initialize the new matrix
            int place = 0; // place of char in string
            for (int row = 0; row < size; row++) // go through all the rows in the matrix
            {
                for (int col = 0; col < size; col++) // go through all the cols in the matrix
                {
                    byte value = Convert.ToByte(text[place] - '0'); // convert char to byte
                    matrix[row, col] = value; // insert value from the string to the matrix
                }
            }
            return matrix;
        }
    }
}
