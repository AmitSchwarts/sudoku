using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.model
{
    public class Matrix
    {
        // Holds a byte matrix of the sudoko string
        private byte[,] board;
        // Holds the side length in the matrix
        public int size;
        // Holds the num of constraints
        private const int NUM_OF_CONSTRAINTS = 4;

        // Creating an object of matrix class
        public Matrix(string text) 
        {
            board = StringToMatrix(text); // convert the string into a byte matrix and insert the result to matrix
        }

        public byte[,] StringToMatrix(string text)
        {
            size = Convert.ToInt32(Math.Sqrt(text.Length)); // size of the new matrix
            byte[,] board = new byte[size, size]; // initialize the new matrix
            int place = 0; // place of char in string
            for (int row = 0; row < size; row++) // go through all the rows in the matrix
            {
                for (int col = 0; col < size; col++) // go through all the cols in the matrix
                {
                    byte value = Convert.ToByte(text[place] - '0'); // convert char to byte
                    board[row, col] = value; // insert value from the string to the matrix
                }
            }
            return board;
        }

        public bool checkValidMat()
        {
            // help arrays to check non-repetition of values
            byte[,] rowsMat = new byte[size, size];
            byte[,] colsMat = new byte[size, size];
            byte[,] boxMat = new byte[size, size];
            // save size of box in board
            int sizeOfBox = (int)Math.Sqrt(size);

            for (int row = 0; row < size; row++) // go through all the rows in the matrix
            {
                for (int col = 0; col < size; col++) // go through all the cols in the matrix
                {
                    int value = board[row, col]; // take this cell number and save it in value 
                    int box = (row / sizeOfBox) * sizeOfBox + col / sizeOfBox; // get the current box
                    if (value != 0) // in case there is a given clue
                    {
                        // in case the value already appear in the arrays, return false (invalid matrix) 
                        if (rowsMat[row, value-1] != 0 || colsMat[col, value-1] != 0 || boxMat[box, value-1] != 0)
                            return false;
                        // else, insert the value in the correct places in the arrays
                        rowsMat[row, value - 1] = 1;
                        colsMat[row, value - 1] = 1;
                        boxMat[row, value - 1] = 1;
                    }
                }
            }
            return true;
        }

        public byte[,] matToExactCoverMat()
        {
            byte[,] coverMat = new byte[size*size*size , size*size*NUM_OF_CONSTRAINTS]; //  create cover matrix
            int currentRow = 0; // the current row in the cover matrix
            int currentCellConstraintColumn = 0; // the current column for the cell constraint
            int currentColumnConstraintColumn = size * size; // the current column for the column constraint
            int currentRowConstraintColumn = 2 * size * size; // the current column for the row constraint
            int currentBoxConstraintColumn = 3 * size * size; // the current column for the box constraint

            for (int row = 0; row < size; row++) // go through all the rows in the matrix
            {
                currentColumnConstraintColumn = size * size; // move the column constraint column back to the start

                for (int col = 0; col < size; col++) // go through all the cols in the matrix
                {
                    int value = board[row, col]; // get the current value in the grid
                    int square = (row / (int)Math.Sqrt(size)) * (int)Math.Sqrt(size) + col / (int)Math.Sqrt(size);  // Get the current box number (1 -> size)

                    for (byte number = 1; number <= size; number++) 
                    {
                        // put a 1 only if the value is 0 or the number is the same as the value
                        if (value == 0 || number == value)
                        {
                            coverMat[currentRow, currentCellConstraintColumn] = 1; // fill the cell constraint
                            coverMat[currentRow, currentColumnConstraintColumn] = 1; // fill the column constraint
                            coverMat[currentRow, currentRowConstraintColumn + number - 1] = 1; // fill the row constraint
                            coverMat[currentRow, currentBoxConstraintColumn + square * size + number - 1] = 1; // fill the square constraint
                        }
                        currentRow++;
                        currentColumnConstraintColumn++;
                    }
                    currentCellConstraintColumn++;
                }
                currentRowConstraintColumn += size;
            }
            return coverMat;
        }

    }
}
