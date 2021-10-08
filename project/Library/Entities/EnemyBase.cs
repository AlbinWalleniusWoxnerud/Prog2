using System;
namespace Library.Entities
{
    //Enemies, inherit stats from EntityBase class, every enemy has different default initialization stats
    public abstract class EnemyBase : EntityBase
    {
        public event EventHandler<EnemyDeathEventArgs> EnemyDeathEventHandler;
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
            var senderReflection = sender.GetType().GetProperties();
            OnEnemyDeath(e);
        }


        private void OnEnemyDeath(EnemyDeathEventArgs e)
        {
            EventHandler<EnemyDeathEventArgs> handler = EnemyDeathEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}