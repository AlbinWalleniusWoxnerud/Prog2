namespace Library.Battle;
/// <summary>
/// Fight is responsible for everything related to combat 
/// </summary>
partial class Fight
{
    /// <summary>
    /// Initialize "Fight" by passing the player and the enemy which the player fights against
    /// </summary>
    /// <param name="player"></param>
    /// <param name="enemy"></param>
    public Fight(Player player, EnemyBase enemy)
    {
        //Add an eventhandler to the enemy's innate DeathEventHandler
        enemy.EnemyDeathEventHandler += Fight.enemy_EnemyDeathEventHandler;
        isCombatansAlive = true;
        battleRound = 1;

        //Invoke the actual combat method
        Combat(player, enemy);
    }
    /// <summary>
    /// While "isCombatansAlive" == true, continue combat until one dies
    /// </summary>
    private static bool isCombatansAlive;
    /// <summary>
    /// Tracks the combat round which determins who defends/attacks
    /// </summary>
    private static int battleRound;
    /// <summary>
    /// Invokes "Combat", pass the player and the enemy which the player fights against
    /// Method is automatically invoked when "Fight" is instanciated
    /// </summary>
    /// <param name="player"></param>
    /// <param name="enemy"></param>
    private static void Combat(Player player, EnemyBase enemy)
    {
        TextRender.Render("");
        TextRender.Render("You prepare for combat");
        TextRender.Render("");
        TextRender.Render("Battle start", color: Text.Color.White);

        while (isCombatansAlive)
        {
            //Bool for determining if the player is defending or not
            bool isPlayerChooseDefend = false;

            if (battleRound % 2 != 0)
            {

                int battleplayerchoice = TextRender.TableOfOptions(header: "Do you", alternatives: "Attack. Defend".Split(". "));

                switch (battleplayerchoice)
                {
                    case 1:
                        TextRender.Render("You ", sameLine: true);
                        TextRender.Render("attack", sameLine: true, color: Text.Color.White);
                        TextRender.Render(" the ", sameLine: true);
                        TextRender.Render($"{enemy.entityType}", sameLine: true, color: Text.Color.Green);
                        TextRender.Render(".");
                        TextRender.Render("");

                        //Invoke "CalculateOutcome", Player chose attack therefor pass player first
                        CalculateOutcome<Player, EnemyBase>(player, enemy);
                        break;
                    case 2:
                        isPlayerChooseDefend = true;
                        TextRender.Render("You ", sameLine: true);
                        TextRender.Render("defend", sameLine: true, color: Text.Color.White);
                        TextRender.Render(" against the ", sameLine: true);
                        TextRender.Render($"{enemy.entityType}", sameLine: true, color: Text.Color.Green);
                        TextRender.Render(".");
                        TextRender.Render(""); ;
                        break;
                }
            }
            else
            {
                TextRender.Render("The ", sameLine: true);
                TextRender.Render($"{enemy.entityType}", sameLine: true, color: Text.Color.Green);
                TextRender.Render(" attacks you.");

                //Invoke "CalculateOutcome", Player chose attack therefor pass player first
                CalculateOutcome(enemy, player, isPlayerChooseDefend);
            }
            battleRound++;
        }
        CheckIfWinner(player, enemy);
    }
}