namespace Text;
public static class TextRender
{
    /// <summary>
    /// Replacement for C# innate Console.WriteLine
    /// </summary>
    /// <param name="text">Text to print</param>
    /// <param name="sameLine">Do not end text with \n</param>
    /// <param name="color">Color of text</param>
    /// <param name="delay">Delay until next patch of text is printed in milliseconds</param>
    /// <param name="speed">Speed of which each individual letter is printed in milliseconds</param>
    public static void Render(string text, bool sameLine = false, Color color = Color.Magenta, int delay = 0, int speed = 30)
    {
        //If player changed settings change them here, because otherwise it will cause a compile time error
        color = color != Color.Magenta ? color : TextColor;
        delay = Delay == 0 ? delay : Delay;
        speed = Speed == 30 ? speed : Speed;

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

    /// <summary>
    /// Variable used to permanently change the delay of printed text
    /// </summary>
    public static int Delay
    {
        get;
        set;
    } = 0;

    /// <summary>
    /// Variable used to permanently change the speed of printed text
    /// </summary>
    public static int Speed
    {
        get;
        set;
    } = 30;

    /// <summary>
    /// Variable used to permanently change the color of printed text
    /// </summary>
    public static Color TextColor
    {
        get;
        set;
    } = Color.Magenta;

    /// <summary>
    /// A method that creates a table of options 
    /// </summary>
    /// <param name="header">The header of the table of options. Ex. If the player is presented with a choice the header would be: "Do you?"</param>
    /// <param name="alternatives">The options given to the player. Ex. "Yes", "No". Must be entered as an array of strings</param>
    /// <returns></returns>
    public static int TableOfOptions(string header, string[] alternatives)
    {
        //Prints out the table with alternatives
        TextRender.Render($"\n{header}");
        for (int i = 0; i < alternatives.Length; i++)
        {
            TextRender.Render($"{i + 1}. {alternatives[i]}");
        }

        //Returns a nullable integer between in the specified range
        int? userInput = GetInCorrectRange(1, alternatives.Length);
        //If the value evaluates to null exit the program
        if (userInput == null) System.Environment.Exit(0);
        return (int)userInput;
    }

    /// <summary>
    /// Returns an integer between the specified range.
    /// The method reads the console for player input and makes sure the input is an integer in the specified range, if it is return it
    /// Method checks for "quit" which will return null
    /// </summary>
    /// <param name="lowerRange"></param>
    /// <param name="upperRange"></param>
    /// <returns></returns>
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

                //If player inputted quit return null
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

}