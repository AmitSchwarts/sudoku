using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.model
{
    public class ColumnHeaderNode : DancingNode
    {
        // Holds the number of connected nodes in the current column
        public int size;
        // Holds the name of the column
        public string name;

        // Constructor for the ColumnHeaderNode class
        public ColumnHeaderNode(string name) : base(null)
        {
            this.size = 0;
            this.name = name;
            this.header = this;
        }

        // Cover operation:
        // unlinking all of the rows that are connected to the current column
        public void Cover()
        {
            this.UnlinkLeftRight(); // Unlink the column header node
            DancingNode rowPointer = this.down;
            while (rowPointer != this) // Traverse the nodes in the current column
            {
                DancingNode nodePointer = rowPointer.right; // Traverse the nodes that are connected to the current row node
                while (rowPointer != nodePointer)
                {
                    // Unlink the current node from its column and update its column's size
                    nodePointer.UnlinkUpDown();
                    nodePointer.header.size--;
                    nodePointer = nodePointer.right;
                }
                rowPointer = rowPointer.down; // Move to the next node (down)
            }
        }

        // Uncover operation:
        // relinking all of the rows that are connected to the current column
        public void Uncover()
        {
            DancingNode rowPointer = this.up; // Get the pointer to the last row
            while (rowPointer != this) // Traverse the nodes in the current column
            {
                DancingNode nodePointer = rowPointer.left; // Traverse the nodes that are connected to the current row node
                while (nodePointer != rowPointer)
                {
                    // Relink the current node to its column and update its column's size
                    nodePointer.RelinkUpDown();
                    nodePointer.header.size++;
                    nodePointer = nodePointer.left;
                }
                rowPointer = rowPointer.up;
            }
            this.RelinkLeftRight(); // Relink the column header node
        }

    }
}
