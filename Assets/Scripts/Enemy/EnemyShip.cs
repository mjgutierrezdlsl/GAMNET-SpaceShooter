using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyShip : MonoBehaviour,IDamageable
{
    [field:SerializeField] public int MaxHealth { get; private set; } = 1;
    
    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _damageAmount = 1;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector3.zero - transform.position).normalized;
        _rb.MovePosition(_rb.position + direction * (_moveSpeed * Time.fixedDeltaTime));
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -=  damageAmount;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlanetController>(out var planet))
        {
            planet.TakeDamage(_damageAmount);    
        }
    }
}
