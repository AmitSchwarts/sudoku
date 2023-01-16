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
        public string STRING_EMPTY = "text cannot be empty";
        public string INCORRECT_SIZE = "text is not in the correct size";
        public string INCORRECT_CHAR = "text containe incorrect char";
        public string NOT_VALID_OPTION = "this choice is not a valid option";
        public string UNVALID_MAT = "unvalid mat";
    }
}
