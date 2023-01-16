using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.view
{
    // view interface containes all the fuction that have to be in class view,
    // regardless of the class implementation methods
    internal interface ViewInterface
    {
        public void startProgram();

        public void stopProgram();
        public void caseConsole();
        public void caseFile();
        public void tryToSolve();
        public bool checkValidation();

    }
}
