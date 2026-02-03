using Core;
using Unity.Netcode;
using UnityEngine;

public class PlayerManager :NetworkSingleton<PlayerManager> 
{
    [SerializeField] private BulletPool _bulletPool;

    public BulletPool InitializeBullets(ulong clientId)
    {
        var pool = Instantiate(_bulletPool);
        pool.gameObject.name = $"Player {clientId + 1} bullets";
        pool.Initialize(clientId);
        return pool;
    }
}
