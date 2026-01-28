using UnityEngine;

public class PlanetController : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 10;
    public int CurrentHealth { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damageable.MaxHealth);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
    }
}
