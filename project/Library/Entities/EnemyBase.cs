namespace Library.Entities;

//Enemies, inherit stats and onDeath method from EntityBase class
public abstract class EnemyBase : EntityBase
{
    public event EventHandler<EnemyDeathEventArgs> EnemyDeathEventHandler;
    internal EnemyBase(EntityType monstertype, int health, int shield, int attack, double defense, int crit)
    {
        this.entityType = monstertype;
        this.health = health;
        this.shield = shield;
        this.attack = attack;
        this.defense = defense;
        this.crit = crit;
        this._alive = true;
    }

    //Override baseclass implementation with an enemy specific variant
    private protected override void EntityDeath()
    {
        OnEnemyDeath(new EnemyDeathEventArgs(this.entityType));
    }

    /// <summary>
    /// Invoked on enemy death.
    /// Checks if subscriber is still subscribed in which case it will invoke the subscriber method
    /// </summary>
    /// <param name="e"></param>
    private void OnEnemyDeath(EnemyDeathEventArgs e)
    {
        EventHandler<EnemyDeathEventArgs> handler = EnemyDeathEventHandler;
        if (handler != null)
        {
            handler(this, e);
        }
    }
}