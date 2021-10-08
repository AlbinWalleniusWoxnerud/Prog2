using Library.Entities;

namespace Library.Entities
{
    namespace Enemies
    {
        internal class Goblin : EnemyBase
        {
            internal Goblin(int health = 25, int shield = 50, int attack = 10, double defense = 0.8, int crit = 20) : base(EntityType.Goblin, health, shield, attack, defense, crit)
            {
            }

            private protected override void EntityDeath()
            {
                base.EntityDeath(this, new EnemyDeathEventArgs(this.entityType));
            }
        }
        internal class HobGoblin : EnemyBase
        {
            internal HobGoblin(int health = 50, int shield = 25, int attack = 5, double defense = 0.50, int crit = 5) : base(EntityType.HobGoblin, health, shield, attack, defense, crit)
            {
            }
        }
        internal class Dragonling : EnemyBase
        {
            internal Dragonling(int health = 200000, int shield = 200000, int attack = 1000000, double defense = 0.000001, int crit = 100) : base(EntityType.Dragonling, health, shield, attack, defense, crit)
            {
            }
        }
        internal class Wolf : EnemyBase
        {
            internal Wolf(int health = 50, int shield = 25, int attack = 10, double defense = 0.80, int crit = 10) : base(EntityType.Wolf, health, shield, attack, defense, crit)
            {
            }
        }
    }
}