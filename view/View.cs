using sudoku.controller;
using sudoku.error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sudoku.view
{
    // View class contains ...
    public class View : ViewInterface
    {
        // Holds the start sudoko string 
        private string text;
        // Holds the resulting sudoku string
        private string solution;
        // Holds a string that represents the user's selection from the menu
        private string userSelect;
        // Holds all constant variables
        private ViewConstants constants;
        // Holds all error massage
        private ErrorMessages error;
        // 
        private Controller turn;

        // Creating an object of type view 
        public View()
        {
            text = "";
            solution = "";
            userSelect = "";
            constants = new ViewConstants();
            error = new ErrorMessages();
            turn = new Controller();
        }

        // Prints a message to open the program
        // and allows selecting an option from the menu until the program is stopped by the user
        public void startProgram()
        {
            Console.WriteLine(constants.WELCOME_TEXT);
            while (userSelect != "e")
            {
                Console.WriteLine(constants.MENU_TEXT);
                userSelect = Console.ReadLine();
                switch (userSelect)
                {
                    case "e": // in case the user chose to exit
                        stopProgram();
                        break;
                    case "c": // in case the user chose to insert from the console
                        getFromConsole();
                        tryToSolve();
                        break;
                    case "f": // in case the user chose to insert from the file
                        getFromFile();
                        tryToSolve();
                        break;
                    default: // any other option not acceptable, error will print and the user will get another option
                        Console.WriteLine(error.NOT_VALID_OPTION);
                        break;
                }
            }
        }

        // in case the user chose to exit from the program
        // an exit message will be print and the program will end
        public void stopProgram()
        {
            Console.WriteLine(constants.EXIT_TEXT);
        }

        // in case the user chose to insert from the console
        // insert board string to this.text
        public void getFromConsole()
        {
            Console.WriteLine(constants.GET_FROM_CONSOLE_TEXT);
            text = Console.ReadLine();
        }

        // in case the user chose to insert from the file
        // insert board string to this.text
        public void getFromFile()
        {

        }

        // if the string in valid, try to solve the board
        // uses checkValidation to check if the string is valid
        public void tryToSolve()
        {
            if (checkValidation())
                turn.tryToSolve();
        }
       
        public bool checkValidation()
        {
            return text != null && Validation.check_correct_chars(text) && Validation.check_size(text);
        }

    }

}
