using System;
using System.Threading;

namespace project
{
    class Battle3Method : Program
    {
        public static bool Battle3()
        {
            SlowRPG_Write("");
            SlowRPG_Write("You both prepare for combat");
            SlowRPG_Write("");
            SlowRPG_Write("Battle start", color: "White");

            //While both combatans are still alive continue combat until one dies
            while (StaticPlayer.player.alive && StaticEnemies.goblin2.alive)
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
                        SlowRPG_Write("attack", sameLine: true, color: "White");
                        SlowRPG_Write(" the ", sameLine: true);
                        SlowRPG_Write("Goblin", sameLine: true, color: "Green");
                        SlowRPG_Write(".");
                        SlowRPG_Write("");

                        //Call the playerattack method with the stats of the enemy, this makes it easy to scale up, the stats are taken from the static instance of the class of the enemy 
                        PlayerAttack(StaticEnemies.goblin2.health, StaticEnemies.goblin2.shield, StaticEnemies.goblin2.defense, out enemy_remaining_shield, out enemy_remaining_health);
                        StaticEnemies.goblin2.health = enemy_remaining_health;
                        StaticEnemies.goblin2.shield = enemy_remaining_shield;

                        break;
                    case 2:
                        playerChooseDefend = true;
                        SlowRPG_Write("You ", sameLine: true);
                        SlowRPG_Write("defend", sameLine: true, color: "White");
                        SlowRPG_Write(" against the ", sameLine: true);
                        SlowRPG_Write("Goblin", sameLine: true, color: "Green");
                        SlowRPG_Write(".");
                        SlowRPG_Write(""); ;
                        break;
                }

                //If there is a winner here the player has won therefore return true
                //The enemies health is passed in for greater compatability with future battles
                if (CheckIfWinner(StaticEnemies.goblin2.health)) return true;

                SlowRPG_Write("The ", sameLine: true);
                SlowRPG_Write("Goblin", sameLine: true, color: "Green");
                SlowRPG_Write(" attacks you.");

                //Call the playergetsattack method with the stats of the enemy, this also makes it easy to scale up
                PlayerGetsAttacked(StaticEnemies.goblin2.crit, StaticEnemies.goblin2.attack, playerChooseDefend);

                //If there is a winner here the player lost therefore return false
                if (CheckIfWinner(StaticEnemies.goblin2.health)) return false;
            }
            //This should not under any circumstances trigger
            return true;
        }
    }
}