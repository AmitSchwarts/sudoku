using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.model
{
    public class DancingNode
    {
        // Holds the nodes that will be connect to header
        public DancingNode left, right, up, down;
        // Holds the current node
        public ColumnHeaderNode header;

        // Constructor for the DancingNode class
        public DancingNode(ColumnHeaderNode header)
        {
            this.left = this.right = this.up = this.down = this; // connect the node to point
            this.header = header; // set the column header node
        }

        // links the given node to the right of the current node
        public void LinkRight(DancingNode node)
        {
            node.right = this.right;
            this.right.left = node;
            this.right = node;
            node.left = this;
        }

        // links the given node to the down of the current node
        public void LinkDown(DancingNode node)
        {
            node.down = this.down;
            this.down.up = node;
            this.down = node;
            node.up = this;
        }

        // cancel the connections of the right and left nodes to the current node
        public void UnlinkLeftRight()
        {
            this.right.left = this.left;
            this.left.right = this.right;
        }

        // cancel the connections of the up and down nodes to the current node
        public void UnlinkUpDown()
        {
            this.down.up = this.up;
            this.up.down = this.down;
        }

        // relinks the current node to the nodes to its right and left
        public void RelinkLeftRight()
        {
            this.left.right = this.right.left = this;
        }

        // relinks the current node to the nodes to its up and down
        public void RelinkUpDown()
        {
            this.up.down = this.down.up = this;
        }
    }
}
