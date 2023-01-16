using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.view
{
    internal class ViewConstants
    {
        public string WELCOME_TEXT = "HELLO and WELLCOME to my sudoku solver:";
        public string MENU_TEXT = "\nMAIN MENU: please enter one of the following options\n" +
            "e to EXIT from the program\n" +
            "f to insert a sudoku board from FILE\n" +
            "c to insert a sudoku board from the CONSOLE\n";
        public string EXIT_TEXT = "\nGood Bey, hope to see yoy again soon ;)";
        public string GET_FROM_CONSOLE_TEXT = "\nplease enter a sudoku board: \n";
        public string GET_FROM_CONSOLE_PATH = "\nplease enter a file path: \n";
        public string BREAK = "\n-----------------------------------------------------------------------------------------\n";
    }
}
