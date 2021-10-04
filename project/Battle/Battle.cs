using System;
using System.Threading;
using ProgramLibrary;
using Text;

namespace Battles
{
    static partial class CBattle
    {
        public static bool Battle(Player player, Enemy enemy)
        {

            //First combat with a goblin
            TextRender.Render("");
            TextRender.Render("You prepare for combat");
            TextRender.Render("");
            TextRender.Render("Battle start", color: Text.Color.White);

            //While alive continue combat until one dies
            while (player._alive && enemy._alive)
            {
                //Init vars
                bool isPlayerChooseDefend = false;

                int battleplayerchoice = TextRender.Table(header: "Do you", alternatives: "Attack. Defend".Split(". "));

                switch (battleplayerchoice)
                {
                    case 1:
                        TextRender.Render("You ", sameLine: true);
                        TextRender.Render("attack", sameLine: true, color: Text.Color.White);
                        TextRender.Render(" the ", sameLine: true);
                        TextRender.Render($"{enemy.entityType}", sameLine: true, color: Text.Color.Green);
                        TextRender.Render(".");
                        TextRender.Render("");
                        // PlayerAttack(player, enemy);
                        CalculateBattleResult<Player, Enemy>(player, enemy);
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

                //If there is a winner here the player has won therefore return true
                if (CheckIfWinner(player, enemy)) return true;


                TextRender.Render("The ", sameLine: true);
                TextRender.Render($"{enemy.entityType}", sameLine: true, color: Text.Color.Green);
                TextRender.Render(" attacks you.");

                //Call the playergetsattack method with the stats of the enemy, this also makes it easy to scale up
                // PlayerGetsAttacked(player, enemy, isPlayerChooseDefend);
                CalculateBattleResult(enemy, player);

                //If there is a winner here the player lost therefore return false
                if (CheckIfWinner(player, enemy)) return false;
            }
            //This should not under any circumstances trigger
            return true;
        }
    }
}