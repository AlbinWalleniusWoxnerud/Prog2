namespace Library.Entities;
public class Player : EntityBase
{
    //Properties specific for the player class
    public event EventHandler<PlayerDeathEventArgs> PlayerDeathEventHandler;
    public int maxhealth { get; set; }
    public int stupidity { get; private set; } = 0;
    public bool hasChestKey { get; set; } = false;
    public bool subjectOfLordBacon { get; set; } = false;
    public bool chooseShield { get; set; } = false;
    public bool hasMeat { get; set; } = false;
    public bool brokenChestKey { get; set; } = false;
    public bool hasBossKey { get; set; } = false;
    public bool hasTrueKey { get; set; } = false;
    public bool finalFight { get; set; } = false;


    /// <summary>
    ///Player initialization with default values 
    /// </summary>
    /// <param name="health"></param>
    /// <param name="maxhealth"></param>
    /// <param name="shield"></param>
    /// <param name="attack"></param>
    /// <param name="defense"></param>
    /// <param name="crit"></param>
    internal Player(int health = 100, int maxhealth = 100, int shield = 0, int attack = 1, double defense = 1, int crit = 10)
    {
        this.health = health;
        this.maxhealth = maxhealth;
        this.shield = shield;
        this.attack = attack;
        this.defense = defense;
        this.crit = crit;
        this._alive = true;
        this.entityType = EntityType.Player;
    }
    //Override baseclass implementation with a player specific variant
    private protected override void EntityDeath()
    {
        OnPlayerDeath(new PlayerDeathEventArgs());
    }

    /// <summary>
    /// /// Invoked on enemy death.
    /// Checks if subscriber is still subscribed in which case it will invoke the subscriber method
    /// </summary>
    /// <param name="e"></param>
    private void OnPlayerDeath(PlayerDeathEventArgs e)
    {
        EventHandler<PlayerDeathEventArgs> handler = PlayerDeathEventHandler;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    //Player specific methods
    public void PartialHeal(int val)
    {
        if (val == 10 || val == 25)
        {
            this.health += val;
        }
        else
        {
            this.TakeDamage(die: true);
        }
    }
    public void FullHeal()
    {
        this.health = maxhealth;
    }

    public void Revive()
    {
        if (this.subjectOfLordBacon)
        {
            this._alive = true;
        }
    }

    //Everytime the player does something stupid increase stupidity and display that their stupidity increased, if stupidity reaches 10 the player dies, currently only works for room 1
    public bool isPlayerDeadStupidity()
    {
        if (this.stupidity > 9)
        {
            TextRender.Render("");
            TextRender.Render("Your stupidity has enraged the gods!", color: Text.Color.Cyan);
            TextRender.Render("");
            TextRender.Render("You died", color: Text.Color.Red);
            TextRender.Render("");

            //Change player status
            this.TakeDamage(die: true);
            return true;
        }
        TextRender.Render("");
        TextRender.Render("Your stupidity increases...", color: Text.Color.DarkGreen);

        //Increase stupidity
        this.stupidity++;
        return false;
    }
}