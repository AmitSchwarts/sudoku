using sudoku.error;
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
        // Holds all error massage
        private ErrorMessages error;
        // Holds if error happend
        private bool errorHappend;

        // Creating an object of type controller 
        public Controller(ErrorMessages error)
        {
            this.error = error;
            board = new Matrix("");
            errorHappend = false;
        }

        // trying to solve the sudoku text
        // return error or result string
        public string tryToSolve(string text)
        {
            board = new Matrix(text); // convert the string into a byte matrix and insert the result to matrix
            if(!board.checkValidMat()) // if the mat isnt valid
            {
                errorHappend = true;
                return error.UNVALID_MAT; // end the trun and return string that represent the failure
            }
            ExactCoverMatrix cover = new ExactCoverMatrix(board.matToExactCoverMat()); // convert from matrix to exact covert matrix
            DancingLinksSolver solver = new DancingLinksSolver(cover.ConvertToDLXRepresentation()); // Create a DLX solver with the DLX representation of the cover
            SolutionHandler solutionHandler = new SolutionHandler(solver.Solve(), board.size); // Create a solution handler
            return solutionHandler.ConvertToStrings()[0]; // Get the string representing the solution
        }
    }
}
