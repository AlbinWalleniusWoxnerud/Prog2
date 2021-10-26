namespace Library.Entities;
public abstract class EntityBase : IEntityBase
{
    private protected int _health;
    public int health { get => _health; private protected set => _health = value; }
    public int shield { get; set; }
    public double attack { get; set; }
    public double defense { get; set; }
    public int crit { get; set; }
    public bool _alive { get; private protected set; }
    public EntityType entityType { get; set; }

    // public virtual bool Battle(Func<Player, Enemy, bool> isVictory)
    // {
    //     return isVictory();
    // }
    public void TakeDamage(double damage = 0, bool die = false)
    {
        this.health -= (int)damage;
        if (this.health <= 0 || die == true)
        {
            this._alive = false;
            EntityDeath();
        }
    }

    private protected virtual void EntityDeath() { }
}