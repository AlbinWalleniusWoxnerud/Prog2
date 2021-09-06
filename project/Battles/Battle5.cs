using System;
using System.Threading;

namespace project
{
    class Battle5Method : Program
    {
        public static bool Battle5()
        {
            SlowRPG_Write("");
            SlowRPG_Write("Battle start", color: "White");

            //While both combatans are still alive continue combat until one dies
            while (StaticPlayer.player.alive && StaticEnemies.Smedd.alive)
            {
                //Init vars
                bool playerChooseDefend = false;
                int enemy_remaining_health;
                int enemy_remaining_shield;

                int battle1_playerchoice = Menu(header: "Do you", alternatives: "Attack. Defend".Split(". "));

                switch (battle1_playerchoice)
                {
                    case 1:
                        SlowRPG_Write("You ", sameLine: true);
                        SlowRPG_Write("attack ", sameLine: true, color: "White");
                        SlowRPG_Write("Smedd", sameLine: true, color: "DarkGreen");
                        SlowRPG_Write(".");
                        SlowRPG_Write("");

                        //Call the playerattack method with the stats of the enemy, this makes it easy to scale up, the stats are taken from the static instance of the class of the enemy 
                        PlayerAttack(StaticEnemies.Smedd.health, StaticEnemies.Smedd.shield, StaticEnemies.Smedd.defense, out enemy_remaining_shield, out enemy_remaining_health);
                        StaticEnemies.Smedd.health = enemy_remaining_health;
                        StaticEnemies.Smedd.shield = enemy_remaining_shield;

                        break;
                    case 2:
                        playerChooseDefend = true;
                        SlowRPG_Write("You ", sameLine: true);
                        SlowRPG_Write("defend", sameLine: true, color: "White");
                        SlowRPG_Write(" against ", sameLine: true);
                        SlowRPG_Write("Smedd", sameLine: true, color: "DarkGreen");
                        SlowRPG_Write(".");
                        SlowRPG_Write(""); ;
                        break;
                }

                //If there is a winner here the player has won therefore return true
                //The enemies health is passed in for greater compatability with future battles
                if (CheckIfWinner(StaticEnemies.Smedd.health)) return true;

                SlowRPG_Write("Smedd", sameLine: true, color: "DarkGreen");
                SlowRPG_Write(" attacks you.");

                //Call the playergetsattack method with the stats of the enemy, this also makes it easy to scale up
                PlayerGetsAttacked(StaticEnemies.Smedd.crit, StaticEnemies.Smedd.attack, playerChooseDefend);

                //If there is a winner here the player lost therefore return false
                if (CheckIfWinnerFinalFight(StaticEnemies.Smedd.health)) return false;
            }
            //This should not under any circumstances trigger
            return true;
        }
    }
}