using sudoku.controller;
using sudoku.error;
using System.Diagnostics;

namespace sudoku.view
{
    public class View : ViewInterface
    {
        // Holds the start sudoko string 
        private string text;
        // Holds the resulting sudoku strings (or the error)
        private string[] solution;
        // Holds a string that represents the user's selection from the menu
        private string userSelect;
        // Holds a string that represents the user's selection for the file path
        private string pathFile;
        // Holds if error happend
        private bool errorHappend;
        // Holds all constant variables
        private ViewConstants constants;
        // Holds all error massage
        private ErrorMessages error;
        // Holds object controller for solving sudoko boards
        private Controller solveSudoku;

        // Creating an object of type view 
        public View()
        {
            text = string.Empty;
            solution = new string[2];
            userSelect = string.Empty;
            pathFile = string.Empty;
            errorHappend = false;
            constants = new ViewConstants();
            error = new ErrorMessages();
            solveSudoku = new Controller(error);
        }

        // prints a message to open the program,
        // allows selecting an option from the menu until the program is stopped by the user
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
                        caseConsole();
                        break;
                    case "f": // in case the user chose to insert from the file
                        caseFile();
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
        public void caseConsole()
        {
            text = getFromConsole(constants.GET_FROM_CONSOLE_TEXT); // get text from console
            tryToSolve(); // try to solve the text
            if (errorHappend)
            {
                printToConsole(solution[0]); // print error to console
            }
            else
            {
                printToConsole(solution[0]); // print solution to console
                printToConsole(constants.BREAK); // add break 
                printToConsole(solution[1]); // print another form of solution to console
            }
        }

        // in case the user chose to insert from the file
        public void caseFile()
        {
            pathFile = getFromConsole("path"); // get file path from console
            while (!File.Exists(pathFile)) // ask for the path again until it exists
            {
                Console.WriteLine("The file was not found. Enter the path again: ");
                pathFile = Console.ReadLine();
            }
            text = getFromFile(); // get text from file
            tryToSolve(); // try to solve the text
            if (errorHappend)
            {
                printToFile(solution[0]); // print error to file
            }
            else
            {
                printToFile(solution[1]); // insert the solution or the error back to the file
                printToConsole(solution[0]); // print solution to console
                printToConsole(constants.BREAK); // add break 
                printToConsole(solution[1]); // print another form of solution to console
            }

        }

        // get string from console
        public string getFromConsole(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        // print string to the console
        public void printToConsole(string text)
        {
            Console.WriteLine(text);
        }

        // insert string board from file
        public string getFromFile()
        {
            return File.ReadAllLines(pathFile)[0];
        }

        // print string to the file
        public void printToFile(string text)
        {
            try
            {
                // Write the meesage in the end of the file with path: this.textFile 
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    sw.WriteLine(text);
                }
            }
            catch
            {
                // catch exception during the opening or writing to the file
                printToConsole(error.FAIL_ACSSES_TO_FILE);
            }
        }

        // if the string in valid, try to solve the board
        // uses checkValidation to check if the string is valid
        public void tryToSolve()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (checkValidation()) // if text is valid
            {
                // try to solve the sudoku:
                // in case of success, solution will containe string of board
                // in case of failer, solution will containe string of the error message
                solution = solveSudoku.tryToSolve(text);
                stopwatch.Stop(); // stop the timer
                if (solveSudoku.errorHappend) // in case error happend
                {
                    errorHappend = true; // update that this situation happened to the data
                }
                else // if there is a result
                {
                    Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms\n"); // print the time it took solve the board
                }
                return;
            }
        }

        // check if the string is valid
        // if it is -> return true
        // else -> return false + save error message in solution
        public bool checkValidation()
        {
            if (text == null) // text cannot be null
            {
                errorHappend = true;
                solution[0] = error.STRING_EMPTY;
                return false;
            }
            else if (text == "") // text cannot be empty
            {
                errorHappend = true;
                solution[0] = error.STRING_EMPTY;
                return false;
            }
            else if (!PreValidation.check_size(text)) // text is not in the correct size
            {
                errorHappend = true;
                solution[0] = error.INCORRECT_SIZE;
                return false;
            }
            else if (!PreValidation.check_correct_chars(text)) // text containe incorrect char
            {
                errorHappend = true;
                solution[0] = error.INCORRECT_CHAR;
                return false;
            }
            return true;
        }
    }
}
