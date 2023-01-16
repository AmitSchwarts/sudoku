using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.model
{
    public class SolutionHandler
    {
        // Holds the size of the board
        private int size;
        // Holds the stack of nodes representing the solution
        private Stack<DancingNode> solution;

        // Constructor for the SolutionHandler class: 
        // gets the stack of nodes representing the solution and the size of the board
        public SolutionHandler(Stack<DancingNode> solution, int size)
        {
            this.size = size;
            this.solution = solution;
        }

        // gets the stack of nodes and convert it to strings that represent sudoku board
        // ues ConvertToMatrix func to get matrix to the solution
        public string[] ConvertToStrings()
        {
            // get matrix to the solution
            int[,] board = ConvertToMatrix();

            // containe the result arr:
            // index 0: containe string that shows as a board 
            // index 1: containe string as it looked in start format
            string[] returnString = new string[2] { "", "" }; 
            for (int i = 0; i < board.GetLength(0); i++) // go through all the rows in the matrix
            {
                for (int j = 0; j < board.GetLength(1); j++) // go through all the cols in the matrix
                {
                    returnString[0] = returnString[0] + " " + (char)(board[i, j] + '0') + " "; // append the current char the board presentation
                    returnString[1] = returnString[1] + (char)(board[i, j] + '0');
                }
                returnString[0] = returnString[0] + "\n"; // move down a line for the board presentation
            }
            return returnString; // return the result strings
        }

        // this function converts the solution stack to a matrix that containe the solution
        private int[,] ConvertToMatrix()
        {
            int[,] board = new int[size, size]; // create the return board
            if (solution.Count == 0) // in casethe stack is empty
                return null; //raise an exception(no solution)
            while (solution.Count != 0) // go through the nodes in the list
            {
                DancingNode node = solution.Pop(); // find the first node in the row (the node whose column is the smallest)
                DancingNode firstNode = node;
                DancingNode nodePointer = node.right;
                while (nodePointer != node) // get the first column of the row
                {
                    if (Convert.ToInt32(nodePointer.header.name) < Convert.ToInt32(firstNode.header.name))
                        firstNode = nodePointer;
                    nodePointer = nodePointer.right;
                }

                // get the names of the first and second headers
                int firstColumnName = Convert.ToInt32(firstNode.header.name);
                int secondColumnName = Convert.ToInt32(firstNode.right.header.name);

                // calculate the indexs in the board and the number to put
                int row = firstColumnName / size;
                int col = firstColumnName % size;
                int num = secondColumnName % size + 1;

                board[row, col] = num; // place the number in the board
            }
            return board; // return the result board
        }
    }
}
