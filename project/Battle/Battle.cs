using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;

namespace Battles
{
    static partial class Battle
    {
        public static bool Combat(Player player, EnemyBase enemy)
        {
            TextRender.Render("");
            TextRender.Render("You prepare for combat");
            TextRender.Render("");
            TextRender.Render("Battle start", color: Text.Color.White);

            while (true)
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
                        CalculateBattleResult<Player, EnemyBase>(player, enemy, isPlayerChooseDefend);
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
                CalculateBattleResult(enemy, player, isPlayerChooseDefend);

                //If there is a winner here the player lost therefore return false
                if (CheckIfWinner(player, enemy)) return false;
            }
        }
    }
}