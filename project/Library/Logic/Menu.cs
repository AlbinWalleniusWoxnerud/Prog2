namespace Library;

internal class Menu
{
    /// <summary>
    /// Controlls whether the game is player again 
    /// </summary>
    internal bool playAgain { get; set; } = false;

    /// <summary>
    /// Allows the player to make changes to some elements of the game
    /// </summary>
    public void Settings()
    {
    start:
        int userInput = TextRender.TableOfOptions(header: "Settings: ", alternatives: "Remove slow text. Change default text color. Return to main menu".Split(". "));
        switch (userInput)
        {
            //Slow text setting
            case 1:
                int userInput2 = TextRender.TableOfOptions(header: "Remove slow text: ", alternatives: "Yes.. No.. Restore default.".Split(". "));
                switch (userInput2)
                {
                    case 1:
                        TextRender.Delay = 0;
                        TextRender.Speed = 0;
                        break;
                    case 2:
                        goto start;
                    case 3:
                        TextRender.Delay = 30;
                        break;
                }
                break;

            //Text color setting
            case 2:
                int userInput3 = TextRender.TableOfOptions(header: "Change default text color: ", alternatives: "Yes.. No.. Restore default.".Split(". "));
                switch (userInput3)
                {
                    case 1:
                        ChangeTextColor();
                        break;
                    case 2:
                        goto start;
                    case 3:
                        TextRender.TextColor = Color.Magenta;
                        break;
                }
                break;

            //Return to main menu
            case 3:
                break;
        }

    }
    //Change text color
    internal void ChangeTextColor()
    {
        //Array of all possibilities
        Color[] allPossibleConsoleColors = { Color.Black, Color.Blue, Color.Cyan, Color.DarkBlue, Color.DarkCyan, Color.DarkGray, Color.DarkGreen, Color.DarkMagenta, Color.DarkRed, Color.DarkYellow, Color.Gray, Color.Green, Color.Magenta, Color.Red, Color.White, Color.Yellow };
        string[] allPossibleConsoleColorsStringFormat = { "Black", "Blue", "Cyan", "DarkBlue", "DarkCyan", "DarkGray", "DarkGreen", "DarkMagenta", "DarkRed", "DarkYellow", "Gray", "Green", "Magenta", "Red", "White", "Yellow" };
        TextRender.Render("Warning! Changing the text color might make text unreadable and or indistinguishable from the background.", color: Color.Red);
        int userInput = TextRender.TableOfOptions(header: "Proceed?", alternatives: "Yes.. No".Split(". "));

        if (userInput == 2) return;

        //Choose between all possibilities
        int userInput2 = TextRender.TableOfOptions(header: "Choose a color", alternatives: allPossibleConsoleColorsStringFormat);
        TextRender.TextColor = allPossibleConsoleColors[userInput2 - 1];
        TextRender.Render($"You choose {allPossibleConsoleColors[userInput2 - 1]}");
    }

    //Check if the player want to play another game
    internal void IsPlayAgain()
    {
        TextRender.Render("Would you like to play again?");
        int input = TextRender.TableOfOptions("Menu:", "Play again.. End game.".Split(". "));
        switch (input)
        {
            case 1:
                this.playAgain = true;
                break;
            case 2:
                break;
        }
    }
    internal void Introduction()
    {
        //An introduction to the game and its maker
        Text.TextRender.Render("~ League of Narnia ~", color: Text.Color.Red);
        Text.TextRender.Render("A textbased game by Albin Inc. in cooperation with Woxnerud Studios.");
        Text.TextRender.Render("Copyright 2021 ©");
        Text.TextRender.Render("");
        Text.TextRender.Render("Enter 'quit' at any time to end the program.", color: Text.Color.White);
    }

    internal void Greetings()
    {
        //A greeting to the player at the start of the game
        TextRender.Render("Welcome to League of Narnia!");
        TextRender.Render("A textbased adventure of glory, heroism and honnor.");
        TextRender.Render("It is time for you to carve out your own path in this world adventurer!");
        TextRender.Render("Are you ready, ", sameLine: true);
        TextRender.Render("for the battles that await, ", sameLine: true);
        TextRender.Render("for the blood that will flow", sameLine: true, color: Text.Color.Red);
        TextRender.Render(", for the .");
        TextRender.Render("But first you must prove yourself worthy, and so your first quest is to conquer the Maze of", sameLine: true);
        TextRender.Render(" Smedd the Terrible", color: Text.Color.Green);
        TextRender.Render("");
        TextRender.Render("As you enter the maze you slip and fall, blacking out as a result...");
        TextRender.Render("...", delay: 1000);
        TextRender.Render("...", delay: 1000);
        TextRender.Render("You wake up in a daze and look around.");
        TextRender.Render("Finding yourself in a pitch black room, thankfully you brought a ", sameLine: true);
        TextRender.Render("torch", sameLine: true, color: Text.Color.White);
        TextRender.Render(" with you.");
        TextRender.Render("");
        TextRender.Render("As you ", sameLine: true);
        TextRender.Render("light", sameLine: true, color: Text.Color.Yellow);
        TextRender.Render(" your torch you are able to make out faint details of the room.");
    }

}