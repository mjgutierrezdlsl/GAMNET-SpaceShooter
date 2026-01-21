using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damageAmount = 5;
    [SerializeField] private float moveSpeed = 5f;
    private BulletPool _pool;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Initialize(Vector2 direction, Vector2 position, BulletPool pool)
    {
        transform.position = position;
        transform.up = direction;
        _pool = pool;
    }

    private void Update()
    {
        transform.position += transform.up * (moveSpeed * Time.deltaTime);
        var viewPortPosition = _camera.WorldToViewportPoint(transform.position);
        if (viewPortPosition.x > 1f || viewPortPosition.x < -1f ||
            viewPortPosition.y > 1f || viewPortPosition.y < -1f
           )
        {
            _pool.Release(this);
        }
    }

}
