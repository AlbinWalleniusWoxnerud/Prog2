using System;
using Text;

namespace ProgramLibrary.Entities
{
    public interface IEntityBase
    {
        int _health { get; }
        int shield { get; }
        double attack { get; }
        double defense { get; }
        int crit { get; }
        bool _alive { get; }
        EntityType entityType { get; }

        void TakeDamage(double damage);
    }

    //Fundamental stats for entities
    public abstract class EntityBase
    {
        public abstract int _health { get; set; }
        public abstract int shield { get; set; }
        public abstract double attack { get; set; }
        public abstract double defense { get; set; }
        public abstract int crit { get; set; }
        public abstract bool _alive { get; private protected set; }
        public abstract EntityType entityType { get; set; }

        // public virtual bool Battle(Func<Player, Enemy, bool> isVictory)
        // {
        //     return isVictory();
        // }
        public void TakeDamage(double damage)
        {
            this._health -= (int)damage;
            if (this._health <= 0)
            {
                EntityDeath();
            }
        }

        private protected virtual void EntityDeath() { }
    }

    internal interface IBase
    {
        void Battle(Player player, Enemy enemy);
    }

    //Player stats and flags
    public class Player : EntityBase, IEntityBase
    {
        public event EventHandler<PlayerDeathEventArgs> PlayerDeathEventHandler;
        public override int shield { get; set; }
        public int maxhealth { get; set; }
        public int stupidity { get; private set; } = 0;
        public bool hasChestKey { get; set; } = false;
        public bool subjectOfLordBacon { get; set; } = false;
        public bool chooseShield { get; set; } = false;
        public bool hasMeat { get; set; } = false;
        public bool brokenChestKey { get; set; } = false;
        public bool hasBossKey { get; set; } = false;
        public bool hasTrueKey { get; set; } = false;

        //Player initialization with default values
        internal Player(int health = 100, int maxhealth = 100, int shield = 0, int attack = 1, double defense = 1, int crit = 10)
        {
            this._health = health;
            this.maxhealth = maxhealth;
            this.shield = shield;
            this.attack = attack;
            this.defense = defense;
            this.crit = crit;
            this._alive = true;
            this.entityType = EntityType.Player;
        }
        private protected override void EntityDeath()
        {
            PlayerDeathEventArgs args = new PlayerDeathEventArgs();
            OnPlayerDeath(args);
        }

        private void OnPlayerDeath(PlayerDeathEventArgs e)
        {
            EventHandler<PlayerDeathEventArgs> handler = PlayerDeathEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        // internal static void Battle(Player player, Enemy enemy)
        // {

        // }

        //Everytime the player does something stupid increase stupidity and display that their stupidity increased, if stupidity reaches 10 the player dies, currently only works for room 1
        public void Stupidity()
        {
            if (this.stupidity > 9)
            {
                TextRender.Render("");
                TextRender.Render("Your stupidity has enraged the gods!", color: Text.Color.Cyan);
                TextRender.Render("");
                TextRender.Render("You died", color: Text.Color.Red);
                TextRender.Render("");

                //Change player status
                this._alive = false;
                return;
            }
            TextRender.Render("");
            TextRender.Render("Your stupidity increases...", color: Text.Color.DarkGreen);
            TextRender.Render("");

            //Increase stupidity
            this.stupidity++;
        }
    }

    //Enemies, inherit stats from EntityBase class, every enemy has different default initialization stats
    public abstract class Enemy : EntityBase
    {
        internal Enemy(EntityType monstertype, int health, int shield, int attack, double defense, int crit)
        {
            this.entityType = monstertype;
            this._health = health;
            this.shield = shield;
            this.attack = attack;
            this.defense = defense;
            this.crit = crit;
            this._alive = true;
        }
    }

    public enum EntityType : byte
    {
        Player,
        Goblin,
        Goblins,
        HobGoblin,
        Wolf,
        Dragonling
    }
    internal class Goblin : Enemy
    {
        internal Goblin(int health = 25, int shield = 50, int attack = 10, double defense = 0.8, int crit = 20) : base(EntityType.Goblin, health, shield, attack, defense, crit)
        {
        }
    }
    internal class HobGoblin : Enemy
    {
        internal HobGoblin(int health = 50, int shield = 25, int attack = 5, double defense = 0.50, int crit = 5) : base(EntityType.HobGoblin, health, shield, attack, defense, crit)
        {
        }
    }
    internal class Dragonling : Enemy
    {
        internal Dragonling(int health = 200000, int shield = 200000, int attack = 1000000, double defense = 0.000001, int crit = 100) : base(EntityType.Dragonling, health, shield, attack, defense, crit)
        {
        }
    }
    internal class Wolf : Enemy
    {
        internal Wolf(int health = 50, int shield = 25, int attack = 10, double defense = 0.80, int crit = 10) : base(EntityType.Wolf, health, shield, attack, defense, crit)
        {
        }
    }
}