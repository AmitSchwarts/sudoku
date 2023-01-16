using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace sudoku.error
{
    // class errorMessages perpose is to containe all the messages that can show up if an error has made
    internal class ErrorMessages
    {
        public string STRING_EMPTY = "\nsudoku board cannot be empty";
        public string INCORRECT_SIZE = "\nthis sudoku board is not in the correct size";
        public string INCORRECT_CHAR = "\nthis sudoku board containe incorrect char";
        public string NOT_VALID_OPTION = "\nthis choice is not a valid option";
        public string UNSOLVE_MAT = "\nthis sudoku board cannot be solved";
        public string FAIL_ACSSES_TO_FILE = "\ni dont succsess to write to your file.";
    }
}
