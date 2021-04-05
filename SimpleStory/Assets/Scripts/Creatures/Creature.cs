using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    enum CreatureAction { idle, moovingRight, moovingLeft, stopMooving };
    [SerializeField]
    private CreatureAction _creatrureAction;

    private Rigidbody2D _rigidbody;

    private const float _maxMovementSpeed = 10.0f;
    private const float _minMovementSpeed = 0.0f;
    private const float _defaultAcceleration = 2.0f;
    private const float _defaultDecelerationSpeed = 1.0f;

    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _accelerationSpeed;
    [SerializeField]
    private float _decelerationSpeed;
    [SerializeField]
    private Vector3 _movementDirection;
    [SerializeField]
    private bool _isGrounded;

    // Этот метод вызывается перед Start(), мб стоит перенести туда, точно не уверен.

    private void Awake()
    {
        _movementSpeed = _minMovementSpeed;
        _accelerationSpeed = _defaultAcceleration;
        _decelerationSpeed = _defaultDecelerationSpeed;

        _creatrureAction = CreatureAction.idle;
        _isGrounded = false;
    
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            _creatrureAction = CreatureAction.moovingRight;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _creatrureAction = CreatureAction.moovingLeft;
        }
        else if (_movementSpeed > 0.0f)
        {
            _creatrureAction = CreatureAction.stopMooving;
        }
        else
        {
            _creatrureAction = CreatureAction.idle;
        }
    }

    private void FixedUpdate()
    {
        if (_creatrureAction == CreatureAction.moovingRight)
        {
            recalculateSpeed(true);
            moveRight();
        }
        else if (_creatrureAction == CreatureAction.moovingLeft)
        {
            recalculateSpeed(true);
            moveLeft();
        }
        else if (_creatrureAction == CreatureAction.stopMooving)
        {
            recalculateSpeed(false);
            postMoovement();
        }
    }

    // Методы для передвижения, нужно будет еще добавить метод Jump()

    private void moveRight() 
    {
        _movementDirection = Vector3.right;
        _rigidbody.MovePosition(_rigidbody.position + (Vector2) _movementDirection * _movementSpeed * Time.fixedDeltaTime);
    }

    private void moveLeft() 
    {
        _movementDirection = Vector3.left;
        _rigidbody.MovePosition(_rigidbody.position + (Vector2) _movementDirection * _movementSpeed * Time.fixedDeltaTime);
    }

    private void postMoovement()
    {
        _rigidbody.MovePosition(_rigidbody.position + (Vector2) _movementDirection * _movementSpeed * Time.fixedDeltaTime);
    }

    // Пересчет скорости, 
    // Нужно будет еще добавить метод IsGrounded() для проверки находится ли объект на земле

    private void recalculateSpeed(bool isMooving)
    {
        if (isMooving)
        {
            if (_movementSpeed < _maxMovementSpeed)
                _movementSpeed += _accelerationSpeed;
            else if (_movementSpeed > _maxMovementSpeed)
                _movementSpeed = _maxMovementSpeed;
        }
        else
        {
            if (_movementSpeed > _minMovementSpeed)
                _movementSpeed -= _decelerationSpeed;
            else if (_movementSpeed < _minMovementSpeed)
                _movementSpeed = _minMovementSpeed;
        }
    }
}
