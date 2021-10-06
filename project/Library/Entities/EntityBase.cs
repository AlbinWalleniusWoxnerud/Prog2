namespace Library.Entities
{
    public abstract class EntityBase
    {
        public virtual int _health { get; private protected set; }
        public virtual int shield { get; set; }
        public virtual double attack { get; set; }
        public virtual double defense { get; set; }
        public virtual int crit { get; set; }
        public virtual bool _alive { get; private protected set; }
        public virtual EntityType entityType { get; set; }

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
}