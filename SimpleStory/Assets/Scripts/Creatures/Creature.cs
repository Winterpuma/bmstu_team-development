using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    enum CreatureAction { idle, moovingRight, moovingLeft, stopMooving };
    [SerializeField]
    private CreatureAction _creatrureAction;

    private const float _maxMovementSpeed = 7.0f;
    private const float _minMovementSpeed = 0.0f;
    private const float _defaultAcceleration = 0.5f;
    private const float _defaultDecelerationSpeed = 0.75f;

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
    }

    // Методы для передвижения, нужно будет еще добавить метод Jump()

    private void moveRight() 
    {
        _movementDirection = Vector3.right;
        transform.position += _movementDirection * _movementSpeed * Time.fixedDeltaTime;
    }

    private void moveLeft() 
    {
        _movementDirection = Vector3.left;
        transform.position += _movementDirection * _movementSpeed * Time.fixedDeltaTime;
    }

    private void postMoovement()
    {
        transform.position += _movementDirection * _movementSpeed * Time.fixedDeltaTime;
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
