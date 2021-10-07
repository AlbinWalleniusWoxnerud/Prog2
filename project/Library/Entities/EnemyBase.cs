namespace Library.Entities
{
    //Enemies, inherit stats from EntityBase class, every enemy has different default initialization stats
    public abstract class EnemyBase
    {
        public override int _health { get; private protected set; }
        public override int shield { get; set; }
        public override double attack { get; set; }
        public override double defense { get; set; }
        public override int crit { get; set; }
        public override bool _alive { get; private protected set; }
        public override EntityType entityType { get; set; }

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
    }
}