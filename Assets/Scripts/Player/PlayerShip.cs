using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : NetworkBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private Transform _spawnPoint;

    private Vector3 _position;
    private float _angle;
    private BulletPool _bulletPool;
    private InputSystem_Actions _input;

    private void Awake()
    {
        _input = new();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsOwner) { return; }
        _input.Player.Enable();
        _input.Player.Attack.started += OnPlayerAttack;
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        if (!IsOwner) { return; }
        _input.Player.Attack.started -= OnPlayerAttack;
        _input.Player.Disable();
    }

    private void OnPlayerAttack(InputAction.CallbackContext context)
    {
        // var bullet = _bulletPool.Get();
        // bullet.transform.parent = _bulletPool.gameObject.transform;
        // bullet.Initialize(transform.up, _spawnPoint.position, _bulletPool);
    }


    public void Initialize(BulletPool pool)
    {
        _bulletPool = pool;
        _angle = Random.Range(0, 360);
    }

    private void Update()
    {
        _angle -= _input.Player.Move.ReadValue<float>() * _moveSpeed * Time.deltaTime;
        _position.x = Mathf.Cos(_angle) * _radius;
        _position.y = Mathf.Sin(_angle) * _radius;

        transform.position = _position;
        transform.up = _position;
    }
}
