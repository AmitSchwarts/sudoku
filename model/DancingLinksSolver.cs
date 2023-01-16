using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.model
{
    public class DancingLinksSolver
    {
        // Holds a stack that represent the nodes that are included in the solution
        private Stack<DancingNode> solution;
        // Holds the DLX cover problem list to solve
        private ColumnHeaderNode root;

        // Constructor for the DancingLinksSolver class
        public DancingLinksSolver(ColumnHeaderNode root)
        {
            this.root = root;
            this.solution = new Stack<DancingNode>();
        }

        // solves the board and return stack of nodes that form the solution
        public Stack<DancingNode> Solve()
        {
            Search(); // call to search functuon
            return solution; // return the solution that 
        }

        // this function finds the rows that form a solution to the exact cover problem
        // and return true in case a solution as been found and false otherwise
        public bool Search()
        { 
            if (root.right == root) // in case there are no more cols, we got a solution and finish
                return true;

            ColumnHeaderNode column = this.SelectColumnHeaderNode(); // choose column
            column.Cover(); // cover the column
            DancingNode rowPointer = column.down; // traverse the nodes in the chosen column

            while (rowPointer != column)
            {
                solution.Push(rowPointer); // Add the current node to the solution
                DancingNode nodePointer = rowPointer.right; // Cover all of the columns that are connected to the current row
                while (nodePointer != rowPointer)
                {
                    nodePointer.header.Cover();
                    nodePointer = nodePointer.right;
                }
                if (Search()) // call the function recursively. If there is a solution, return true
                    return true;
                // get the last node in the solution and its column
                rowPointer = solution.Pop();
                column = rowPointer.header;
                // uncover all of the columns that are connected to the current row
                nodePointer = rowPointer.left;
                while (nodePointer != rowPointer)
                {
                    nodePointer.header.Uncover();
                    nodePointer = nodePointer.left;
                }
                rowPointer = rowPointer.down;
            }     
            column.Uncover(); // uncover the current column
            return false;
        }

        // this function chooses column header node which has the least amount of nodes connected to it downward  
        public ColumnHeaderNode SelectColumnHeaderNode()
        {
            ColumnHeaderNode minColNode = (ColumnHeaderNode)root.right;// the header node with the minimum value
            ColumnHeaderNode colPointer = (ColumnHeaderNode)root.right; // a pointer to traverse the headers
            while (colPointer != root) // traverse the headers
            {
                if (colPointer.size < minColNode.size) // in case the current header's value is smaller than the minimum value
                    minColNode = colPointer; // set it as the new min node
                colPointer = (ColumnHeaderNode)colPointer.right;
            }
            return minColNode; // return the minimum node
        }
    }
}
