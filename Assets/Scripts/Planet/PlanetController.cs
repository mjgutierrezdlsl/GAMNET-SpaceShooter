using Unity.Netcode;
using UnityEngine;

public class PlanetController : NetworkBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 10;
    public NetworkVariable<int> CurrentHealth { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damageable.MaxHealth);
        }
    }
    private void Update()
    {
        if (IsServer && Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        CurrentHealth.Value -= damageAmount;
    }
}
