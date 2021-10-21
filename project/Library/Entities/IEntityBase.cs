using Library.Entities;

namespace Library.Entities
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

        void TakeDamage(double damage, bool die);
    }
}