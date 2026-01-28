using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(NetworkObject))]
public class EnemyController : NetworkBehaviour,IDamageable
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 1;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _damageAmount = 1;
    
    private Rigidbody2D _rigidbody2D;
    public NetworkObject NetworkObject { get; private set; }

    private int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = value;
            if (_currentHealth > 0) return;
            _currentHealth = 0;
            if (IsServer)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {_rigidbody2D = GetComponent<Rigidbody2D>();
        NetworkObject = GetComponent<NetworkObject>();
    }

    private void OnEnable()
    {
        CurrentHealth = MaxHealth;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector3.zero-transform.position).normalized;
        _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (_moveSpeed * Time.fixedDeltaTime));
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) return;
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damageAmount);
        }
    }
}
