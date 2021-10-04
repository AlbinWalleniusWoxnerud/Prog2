using System;
using System.Threading;
using ProgramLibrary;
using Text;
using System.Collections.Generic;

namespace Battles
{
    static partial class CBattle
    {
        public static void CalculateBattleResult<T, U>(T attacker, U defender) where T : EntityBase where U : EntityBase
        {
            double damage = attacker.attack * defender.defense;
            TextRender.Render("Damage dealt reduced by ", sameLine: true);
            TextRender.Render($"{Math.Round((1 - defender.defense) * 100)}%", sameLine: true, color: Text.Color.White);
            TextRender.Render($" due to {defender.entityType}'s defense.");


            //If attacker crits 2x the damage
            if (/* (100 - attacker.crit) <= new Random().Next(1, 100) */true)
            {
                TextRender.Render($"{attacker.entityType} crit!", color: Text.Color.White);
                damage *= 2;
            }

            if ((defender.shield - damage) >= 0)
            {
                //Cast damage to int 
                defender.shield -= (int)damage;

                TextRender.Render($"{(int)damage}", sameLine: true, color: Text.Color.White);
                TextRender.Render($" damage blocked by {defender.entityType}'s shield.");
                TextRender.Render($"{defender.entityType} has ", sameLine: true);
                TextRender.Render($"{defender.shield}", sameLine: true, color: Text.Color.White);
                TextRender.Render(" remaining shield.");
            }

            //If the attack destoys the shield
            else if ((defender.shield - damage) < 0 && defender.shield > 0)
            {
                TextRender.Render($"{damage - defender.shield}", sameLine: true, color: Text.Color.White);
                TextRender.Render($" damage blocked by {defender.entityType}'s shield.");

                //Remaining damage after shield blocked some of it
                damage -= defender.shield;

                //defender shield is destoyed since (defenderShield - damage) was less than 0
                defender.shield = 0;
                TextRender.Render($"{defender.entityType} shield was destroyed.", color: Text.Color.White);
                TextRender.Render($"{(int)damage}", sameLine: true, color: Text.Color.White);
                TextRender.Render($" was dealt directly to {defender.entityType} HP.");

                defender.TakeDamage(damage);

                TextRender.Render($"{defender.entityType} has ", sameLine: true);
                TextRender.Render($"{defender._health}", sameLine: true, color: Text.Color.White);
                TextRender.Render(" HP remaining.");
            }

            //Enemies shield is destroyed so deal damage directly to defender hp
            else
            {
                TextRender.Render($"{(int)damage}", sameLine: true, color: Text.Color.White);
                TextRender.Render($" was dealt directly to {defender.entityType} HP.");

                defender.TakeDamage(damage);

                TextRender.Render($"{defender.entityType} has ", sameLine: true);
                TextRender.Render($"{defender._health}", sameLine: true, color: Text.Color.White);
                TextRender.Render(" HP remaining.");
            }

            TextRender.Render("");
        }

        public static bool CheckIfWinner(Player player, Enemy enemy)
        {
            if (enemy._health <= 0)
            {
                TextRender.Render("");
                TextRender.Render("You won the battle!", color: Text.Color.White);
                TextRender.Render("");
                return true;
            }
            if (player._health <= 0)
            {
                TextRender.Render("");
                TextRender.Render("You lost the battle, and died!", color: Text.Color.DarkRed);
                TextRender.Render("");
                // player.alive = false;
                return true;
            }
            return false;
        }
        public static bool CheckIfWinnerFinalFight(Player player, Enemy enemy)
        {
            if (enemy._health <= 0)
            {
                TextRender.Render("");
                TextRender.Render("You won the battle!", color: Text.Color.White);
                TextRender.Render("");
                return true;
            }
            if (player._health <= 0)
            {
                TextRender.Render("");
                TextRender.Render("You lost the battle!", color: Text.Color.DarkRed);
                TextRender.Render("");
                return true;
            }
            return false;
        }

        public static void player_PlayerDeathEventHandler(Object sender, PlayerDeathEventArgs e)
        {
            Console.WriteLine($"The player died at {e.TimeOfDeath}.");
        }
    }
}