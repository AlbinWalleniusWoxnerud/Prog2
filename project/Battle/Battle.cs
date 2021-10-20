using System;
using System.Threading;
using Library;
using Library.Entities;
using Text;

namespace Battles
{
    partial class Battle
    {
        public Battle(Player player, EnemyBase enemy)
        {
            isCombatansAlive = true;
            battleRound = 1;
            Combat(player, enemy);
        }
        private static bool isCombatansAlive;
        private static int battleRound;
        private static void Combat(Player player, EnemyBase enemy)
        {
            TextRender.Render("");
            TextRender.Render("You prepare for combat");
            TextRender.Render("");
            TextRender.Render("Battle start", color: Text.Color.White);

            while (isCombatansAlive)
            {
                //Init vars
                bool isPlayerChooseDefend = false;

                if (battleRound % 2 != 0)
                {

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
                            CalculateBattleResult<Player, EnemyBase>(player, enemy);
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

                    //Call the playergetsattack method with the stats of the enemy, this also makes it easy to scale up
                    CalculateBattleResult(enemy, player, isPlayerChooseDefend);
                }
                battleRound++;
                if (CheckIfWinner(player, enemy)) return;
            }
        }
    }
}