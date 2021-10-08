using System;
namespace Library.Entities
{
    //Enemies, inherit stats from EntityBase class, every enemy has different default initialization stats
    public abstract class EnemyBase : EntityBase
    {
        internal EnemyBase(EntityType monstertype, int health, int shield, int attack, double defense, int crit)
        {
            this.entityType = monstertype;
            this._health = health;
            this.shield = shield;
            this.attack = attack;
            this.defense = defense;
            this.crit = crit;
            this._alive = true;
        }

        private protected void EntityDeath(object sender, EnemyDeathEventArgs e)
        {
            EnemyDeathEventArgs args = new EnemyDeathEventArgs();
            OnEnemyDeath(args);
        }
        private void OnEnemyDeath(EnemyDeathEventArgs e)
        {
            EventHandler<EnemyDeathEventArgs> handler = PlayerDeathEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}