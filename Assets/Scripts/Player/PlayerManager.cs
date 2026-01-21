using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerShip _shipPrefab;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _playerSpawnParent,_bulletPoolSpawnParent;

    private void Start()
    {
        SpawnPlayerShip(0);
    }

    private void SpawnPlayerShip(int index)
    {
        var ship = Instantiate(_shipPrefab,_playerSpawnParent);
        ship.gameObject.name = $"Player {index + 1} ship";
        var pool = Instantiate(_bulletPool, _bulletPoolSpawnParent);
        pool.gameObject.name = $"Player {index + 1} bullets";
        ship.Initialize(pool);
    }
}
