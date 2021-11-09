namespace Library.Entities;
public abstract class EntityBase : IEntityBase
{
    //General properties which all entities inherit
    private int _health;
    public int health { get => _health; private protected set => _health = value; }
    public int shield { get; set; }
    public double attack { get; set; }
    public double defense { get; set; }
    public int crit { get; set; }
    public bool _alive { get; private protected set; }
    public EntityType entityType { get; set; }

    /// <summary>
    /// Invoked whenever an entity takes damage, checks if it killed it
    /// Has the option of instantly killing said entity
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="die">Instantly kill the entity</param>
    public void TakeDamage(double damage = 0, bool die = false)
    {
        this.health -= (int)damage;
        if (this.health <= 0 || die == true)
        {
            this._alive = false;
            EntityDeath();
        }
    }
    /// <summary>
    /// Automatically invokes on entity death.
    /// Override to specify behavior
    /// </summary>
    private protected virtual void EntityDeath() { }
}