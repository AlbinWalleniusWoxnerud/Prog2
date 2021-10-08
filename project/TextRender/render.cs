using System;
using System.Threading;

namespace Text
{
    public static class TextRender
    {
        public static void Render(string text, bool sameLine = false, Color color = Color.Magenta, int delay = 0, int speed = 0)
        {
            //If player changed settings change them here, because otherwise it will cause a compile time error
            color = color != Color.Magenta ? color : TextColor;
            color = Color.Magenta;
            delay = delay == 0 ? delay : Delay;
            speed = speed == 30 ? speed : Speed;


            Console.ForegroundColor = (System.ConsoleColor)color;
            foreach (char letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(speed);
            }
            Thread.Sleep(Delay);
            Console.ResetColor();
            if (sameLine) return;
            Console.WriteLine();
        }

        //A method that creates a table with specific alternatives
        public static int Table(string header, string[] alternatives)
        {
            //Prints out the table with alternatives
            TextRender.Render($"\n{header}");
            for (int i = 0; i < alternatives.Length; i++)
            {
                TextRender.Render($"{i + 1}. {alternatives[i]}");
            }

            //Get an input corresponding to one the 3 alternatives given through the GetInCorrectRange() method, see GetInCorrectRange() for further info
            int? userInput = GetInCorrectRange(1, alternatives.Length);
            if (userInput == null) System.Environment.Exit(0);
            return (int)userInput;
        }

        //Method to get an integer in a certain range, also check or 'quit'
        private static int? GetInCorrectRange(int lowerRange, int upperRange)
        {
            //Init vars
            bool isInRange = false;
            int userInput = 0;

            //While the given user input isn't in the range repeat until it is
            while (!isInRange)
            {
                //Init var
                bool isInt = false;

                //While the given input isn't an integer repeat until it is
                while (!isInt)
                {
                    string rawUserInput = Console.ReadLine();
                    if (rawUserInput == "quit") return null;
                    isInt = int.TryParse(rawUserInput, out userInput);

                    //If given input isn't an integer tell the user
                    if (!isInt)
                    {
                        TextRender.Render("Input must be an integer, try again!", color: Text.Color.Red);
                    }
                }

                //Check if given input is in the given range
                if (lowerRange <= userInput && userInput <= upperRange)
                {
                    //If it is end the while loop and return the integer
                    isInRange = true;
                }

                //If it isn't in the range tell the user the correct range and make them enter a new input
                else
                {
                    TextRender.Render($"Input must be between {lowerRange} and {upperRange}, try again!", color: Text.Color.Red);
                }
            }

            //Return the correct input which is an integer in the correct range
            return userInput;
        }

        public static int Delay
        {
            get;
            set;
        }

        public static int Speed
        {
            get;
            set;
        }

        public static Color TextColor
        {
            get;
            set;
        }
    }
    public enum Color : byte
    {
        Black = 0,
        DarkBlue = 1,
        DarkGreen = 2,
        DarkCyan = 3,
        DarkRed = 4,
        DarkMagenta = 5,
        DarkYellow = 6,
        Gray = 7,
        DarkGray = 8,
        Blue = 9,
        Green = 10,
        Cyan = 11,
        Red = 12,
        Magenta = 13,
        Yellow = 14,
        White = 15
    }

}