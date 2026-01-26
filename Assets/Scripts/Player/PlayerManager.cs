using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _bulletPoolSpawnParent;
    [SerializeField] private Dictionary<ulong, PlayerShip> _playerShips = new();

    public void AddPlayer(PlayerShip ship)
    {
        print($"Ship {ship.OwnerClientId} added");
        _playerShips.Add(ship.OwnerClientId, ship);

        var pool = Instantiate(_bulletPool, _bulletPoolSpawnParent);
        pool.Initialize(ship.OwnerClientId);
        ship.Initialize(pool);
    }

    public void RemovePlayer(ulong clientId)
    {
        _playerShips.Remove(clientId);
        print($"Ship {clientId} removed");
    }

}
