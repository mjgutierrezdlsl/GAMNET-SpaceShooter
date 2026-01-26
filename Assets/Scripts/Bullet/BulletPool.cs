using Unity.Netcode;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    private ObjectPool<Bullet> _pool;
    private NetworkObject _networkObject;
    private ulong _clientId;

    public void Initialize(ulong clientId)
    {
        _clientId = clientId;
        _pool = new ObjectPool<Bullet>(
            OnCreateItem,
            OnGetItem,
            OnReleaseItem,
            OnDestroyItem
            );
    }

    private Bullet OnCreateItem()
    {
        var bullet = Instantiate(_prefab);
        _networkObject = bullet.GetComponent<NetworkObject>();
        _networkObject.SpawnWithOwnership(_clientId);
        return bullet;
    }

    private void OnGetItem(Bullet bullet) => bullet.gameObject.SetActive(true);
    private void OnReleaseItem(Bullet bullet) => bullet.gameObject.SetActive(false);
    private void OnDestroyItem(Bullet bullet)
    {
        _networkObject.DontDestroyWithOwner = true;
        _networkObject.Despawn();
    }

    public Bullet Get() => _pool.Get();
    public void Release(Bullet bullet) => _pool.Release(bullet);
}
