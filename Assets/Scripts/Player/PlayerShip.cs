using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private Vector3 _position;
    [SerializeField]private float _moveSpeed = 3f;
    [SerializeField] private float _radius = 3f;
    private float _angle;

    private void Start()
    {
        _angle = Random.Range(0, 360);
    }

    private void Update()
    {
         _angle -= Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime;
        _position.x = Mathf.Cos(_angle) *  _radius;
        _position.y = Mathf.Sin(_angle) * _radius;

        transform.position = _position;
        transform.up = _position;
    }
}
