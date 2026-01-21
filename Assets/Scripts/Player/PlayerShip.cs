using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]private float _moveSpeed = 3f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private Transform _spawnPoint;
    
    private Vector3 _position;
    private float _angle;
    private BulletPool _bulletPool;

    public void Initialize(BulletPool pool)
    {
        _bulletPool = pool;
        _angle = Random.Range(0, 360);
    }

    private void Update()
    {
         _angle -= Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime;
        _position.x = Mathf.Cos(_angle) *  _radius;
        _position.y = Mathf.Sin(_angle) * _radius;

        transform.position = _position;
        transform.up = _position;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            var bullet = _bulletPool.Get();
            bullet.transform.parent = _bulletPool.gameObject.transform;
            bullet.Initialize(transform.up,_spawnPoint.position,_bulletPool);
        }
    }
}
