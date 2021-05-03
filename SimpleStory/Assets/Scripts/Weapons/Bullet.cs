using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    [SerializeField]
    protected Vector2 _movementDirection;
    public Vector2 MovementDirection 
    {
        get 
        { 
            return _movementDirection;
        } 
        set 
        { 
            _movementDirection = value;
        } 
    }

    protected const float _maxMovementSpeed = 20.0f;
    protected const float _minMovementSpeed = 00.0f;
    protected const float _movementForce = 80.0f;
    protected const float _defaultDamage = 10.0f;
    protected const int _enemyLayerNumber = 7;
    protected const double _defaultDestoryTime = 4.0f;

    protected double _damage;

    protected double _timeUntilDestory;

    private void Awake()
    {
        _movementDirection = Vector2.zero;
        _damage  = _defaultDamage;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();

        _timeUntilDestory = _defaultDestoryTime;
    }

    private void Update()
    {
        _timeUntilDestory -= Time.deltaTime;
        if (_timeUntilDestory <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void FixedUpdate() 
    {
        Move();
    }

    protected void Move() 
    {
        _rigidbody.AddForce(_movementDirection * _movementForce);

        if (Mathf.Abs(_rigidbody.velocity.x) > _maxMovementSpeed)
        {
            _rigidbody.velocity = new Vector2(Mathf.Sign(_rigidbody.velocity.x) * _maxMovementSpeed, _rigidbody.velocity.y);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == _enemyLayerNumber)
        {
            Debug.Log("Bullet entered col");
            Destroy(this.gameObject);
        }
    }
}
