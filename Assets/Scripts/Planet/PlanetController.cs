using System;
using Unity.Netcode;
using UnityEngine;

public class PlanetController : NetworkBehaviour,IDamageable
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 10;
    [SerializeField] int _currentHealth = 10;

    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                OnHealthChanged?.Invoke(_currentHealth,MaxHealth);
                OnHealthDepleted?.Invoke();
            }
            OnHealthChanged?.Invoke(_currentHealth,MaxHealth);
        }
    }

    public event Action<int,int> OnHealthChanged;
    public event Action OnHealthDepleted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damageable.MaxHealth);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!IsServer) return;
        CurrentHealth -= damageAmount;
        print($"Planet: {CurrentHealth} / {MaxHealth}");
    }
}
