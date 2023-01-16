using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.model
{
    public class ExactCoverMatrix
    {
        // Holds the ExactCoverMatrix board
        private byte[,] board;

        // Constructor for the ExactCoverMatrix class
        public ExactCoverMatrix(byte[,] board)
        {
            this.board = board;
        }

        // converts the byte cover matrix into DLX
        public ColumnHeaderNode ConvertToDLX()
        {
            ColumnHeaderNode root = new ColumnHeaderNode("Root"); // create the root node
            ColumnHeaderNode[] headers = new ColumnHeaderNode[board.GetLength(1)]; // create the header nodes and save them in an array
            for (int i = 0; i < board.GetLength(1); i++)
            {
                // new header node
                ColumnHeaderNode currentHeader = new ColumnHeaderNode(i.ToString()); 
                headers[i] = currentHeader;
                // link the current header to the rest
                root.LinkRight(currentHeader);
                root = (ColumnHeaderNode)currentHeader;
            }
            root = (ColumnHeaderNode)root.right.header; // get the root node again
            for (int i = 0; i < board.GetLength(0); i++) // go through all the rows in the matrix
            {
                DancingNode? previousNode = null; // the previous node in the current row
                for (int j = 0; j < board.GetLength(1); j++) // go through all the columns in the matrix
                {
                    if (board[i, j] == 1) // in case the cell is not empty
                    {
                        ColumnHeaderNode currentHeader = headers[j]; // get the header node of the current column
                        DancingNode newNode = new DancingNode(currentHeader); // build new DancingNode
                        currentHeader.up.LinkDown(newNode); // connect between the node and its column
                        
                        if (previousNode == null) // in case the previous node is null
                        {
                            previousNode = newNode; // set the current node to be the previous
                        }
                        else 
                        {
                            // connect the current node to the previous and update the previous
                            previousNode.LinkRight(newNode);
                            previousNode = previousNode.right;
                        }
                        currentHeader.size++; // update the size field of the current header
                    }
                }
            }
            return root; // return the DLX list
        }
    }
}
