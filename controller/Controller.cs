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
        public bool errorHappend;

        // Creating an object of type controller 
        public Controller(ErrorMessages error)
        {
            this.error = error;
            board = new Matrix("");
            errorHappend = false;
        }

        // trying to solve the sudoku text
        // return error or result string
        public string[] tryToSolve(string text)
        {
            board = new Matrix(text); // convert the string into a byte matrix and insert the result to matrix
            string[] errorCase = new string[2];
            if(!board.checkValidMat()) // if the mat isnt valid
            {
                errorHappend = true;
                errorCase[0] = error.UNSOLVE_MAT;
                return errorCase; // end the trun and return arr of string that in place 0 represent the failure
            }
            ExactCoverMatrix cover = new ExactCoverMatrix(board.matToExactCoverMat()); // convert from matrix to exact covert matrix
            DancingLinksSolver solver = new DancingLinksSolver(cover.ConvertToDLX()); // Create a DLX solver with the DLX representation of the cover
            SolutionHandler solutionHandler = new SolutionHandler(solver.Solve(), board.size); // Create a solution handler
            return solutionHandler.ConvertToStrings(); // Get the string representing the solution in 2 ways
        }
    }
}
