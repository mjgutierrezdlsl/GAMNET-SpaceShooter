using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
            OnCreateItem,
            OnGetItem,
            OnReleaseItem,
            OnDestroyItem
            );
    }

    private Bullet OnCreateItem() => Instantiate(_prefab);
    private void OnGetItem(Bullet bullet) => bullet.gameObject.SetActive(true);
    private void OnReleaseItem(Bullet bullet) => bullet.gameObject.SetActive(false);
    private void OnDestroyItem(Bullet bullet) => Destroy(bullet.gameObject);

    public Bullet Get() => _pool.Get();
    public void Release(Bullet bullet) => _pool.Release(bullet);
}
