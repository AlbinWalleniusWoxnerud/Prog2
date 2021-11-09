namespace Library.Battle;

partial class Fight
{
    /// <summary>
    /// Calculates the outcome of current attack/defense.
    /// Passed entities must inherit from EntityBase.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="attacker">Pass the entity that is attacking</param>
    /// <param name="defender">Pass the entity that is defending</param>
    /// <param name="IsPlayerDefending">Is the player defending when attacked</param>
    private static void CalculateOutcome<T, U>(T attacker, U defender, bool IsPlayerDefending = false) where T : EntityBase where U : EntityBase
    {
        //Local variable damage to store temporary value
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

        //Monsters always defend, player only defends when choosing to do so
        if (defender is EnemyBase || IsPlayerDefending)
        {
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
            else if ((defender.shield - damage) < 0 || defender.shield > 0)
            {
                TextRender.Render($"{defender.shield}", sameLine: true, color: Text.Color.White);
                TextRender.Render($" damage blocked by {defender.entityType}'s shield.");

                //Remaining damage after shield blocked some of it
                damage -= defender.shield;

                //defender shield is destoyed since (defenderShield - damage) was less than 0
                defender.shield = 0;
                TextRender.Render($"{defender.entityType} shield was destroyed.", color: Text.Color.White);
                TextRender.Render($"{(int)damage}", sameLine: true, color: Text.Color.White);
                TextRender.Render($" was dealt directly to {defender.entityType} HP.");

                if (isDefenderAliveAfterDamage(defender, damage) == false) return;

                TextRender.Render($"{defender.entityType} has ", sameLine: true);
                TextRender.Render($"{defender.health}", sameLine: true, color: Text.Color.White);
                TextRender.Render(" HP remaining.");
            }
            else
            {
                DefenderTakesDirectDamage();
            }
        }

        //The player did not chose to defend
        else
        {
            DefenderTakesDirectDamage();
        }

        TextRender.Render("");

        //Defender takes damage directly to HP
        void DefenderTakesDirectDamage()
        {
            TextRender.Render($"{(int)damage}", sameLine: true, color: Text.Color.White);
            TextRender.Render($" was dealt directly to {defender.entityType} HP.");

            if (isDefenderAliveAfterDamage(defender, damage) == false) return;

            TextRender.Render($"{defender.entityType} has ", sameLine: true);
            TextRender.Render($"{defender.health}", sameLine: true, color: Text.Color.White);
            TextRender.Render(" HP remaining.");
        }

        //Local method to check if the defender survived the attack
        static bool isDefenderAliveAfterDamage<O>(O defender, double damage) where O : EntityBase
        {
            defender.TakeDamage(damage);
            if (defender._alive == false) return false;
            return true;
        }
    }

    /// <summary>
    /// Post combat check who won and print message depending on winner
    /// </summary>
    /// <param name="player"></param>
    /// <param name="enemy"></param>
    /// <returns></returns>
    public static bool CheckIfWinner(EntityBase player, EntityBase enemy)
    {
        if (enemy._alive == false)
        {
            TextRender.Render("");
            TextRender.Render("You won the battle!", color: Text.Color.White);
            TextRender.Render("");
            return true;
        }
        else
        {
            if (enemy.entityType is EntityType.Dragonling)
            {
                TextRender.Render("");
                TextRender.Render("You lost the battle!", color: Text.Color.DarkRed);
                TextRender.Render("");
                return true;
            }
            TextRender.Render("");
            TextRender.Render("You lost the battle, and died!", color: Text.Color.DarkRed);
            TextRender.Render("");
            return true;
        }
    }

    //On entity death one of the two will trigger, "isCombatansAlive" will equal false which will end the combat
    public static void player_PlayerDeathEventHandler(Object sender, PlayerDeathEventArgs e)
    {
        if ((Boolean)sender.GetType().GetProperty("finalFight").GetValue(sender))
        {
            TextRender.Render("");
            TextRender.Render($"The player died at {e.TimeOfDeath}.", color: Text.Color.DarkGray);
        }
        else
        {
            TextRender.Render($"The player died at {e.TimeOfDeath}.", color: Text.Color.DarkRed);
        }
        isCombatansAlive = false;
    }
    public static void enemy_EnemyDeathEventHandler(Object sender, EnemyDeathEventArgs e)
    {
        TextRender.Render($"The {e.DeadEnemyType} died at {e.TimeOfDeath}.", color: Text.Color.DarkRed);
        isCombatansAlive = false;
    }
}