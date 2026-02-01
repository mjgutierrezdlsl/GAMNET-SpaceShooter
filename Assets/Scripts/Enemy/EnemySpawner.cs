using Unity.Netcode;
using UnityEngine;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField] private EnemyShip _prefab;
    [SerializeField] private float _minSpawnRate=1f, _maxSpawnRate= 5f;

    private Camera _camera;
    private float _elapsedTime;
    private float _spawnRate;

    private void Awake()
    {
        _camera = Camera.main;
    }
    
    private void Start()
    {
        _spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
    }

    private void Update()
    {
        if (!IsServer)
        {
            return;
        }
        
        if (_elapsedTime < _spawnRate)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            Spawn();
            _elapsedTime = 0;
            _spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
        }
    }

    private void Spawn()
    {
        var maxBounds = _camera.ScreenToWorldPoint(new(Screen.width, Screen.height));
        var minBounds = _camera.ScreenToWorldPoint(Vector3.zero);
        var randomizer = Random.Range(0f, 1f);
        Vector3 spawnPos = randomizer switch
        {
            // spawn left side of screen
            < 0.25f => new(minBounds.x, Random.Range(minBounds.y, maxBounds.y)),
            // spawn right side of screen
            >= 0.25f and < 0.5f => new(maxBounds.x, Random.Range(minBounds.y, maxBounds.y)),
            // spawn top side of the screen
            >= 0.5f and < 0.75f => new(Random.Range(minBounds.x, maxBounds.x), maxBounds.y),
            // spawn to bottom side of the screen
            >= 0.75f and <= 1f => new(Random.Range(minBounds.x, maxBounds.x), minBounds.y),
            // default always spawns on top
            _ => new(Random.Range(minBounds.x, maxBounds.x), maxBounds.y),
        };
        var ship = Instantiate(_prefab, spawnPos, Quaternion.identity);
        ship.NetworkObject.Spawn();
    }
}
