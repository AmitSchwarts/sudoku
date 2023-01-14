using sudoku.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace sudoku.controller
{
    internal class Controller
    {
        // Holds a object that represent byte matrix of the sudoko string
        private Matrix board;

        // Creating an object of type controller 
        public Controller() {}

        public void tryToSolve(string text)
        {
            board = new Matrix(text); // convert the string into a byte matrix and insert the result to matrix
            if(!board.checkValidMat()) // if the mat isnt valid
            {
                // print the failure
                return; // end the trun
            }
        }
    }
}
