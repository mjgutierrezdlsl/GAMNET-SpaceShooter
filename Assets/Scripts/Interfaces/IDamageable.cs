    public interface IDamageable
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }
        void TakeDamage(int damageAmount);
    }