using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    private const float _maxMovementSpeed = 7.0f;
    private const float _minMovementSpeed = 0.0f;

    [SerializeField]
    private float _accelerationSpeed;
    private const float _defaultAcceleration = 0.5f;

    [SerializeField]
    private float _decelerationSpeed;
    private const float _defaultDecelerationSpeed = 0.75f;

    [SerializeField]
    private Vector3 _movementDirection;

    enum CreatureAction { idle, moovingRight, moovingLeft, stopMooving };
    [SerializeField]
    private CreatureAction _creatrureAction;

    private bool _isGrounded;

    private void Awake()
    {
        _movementSpeed = _minMovementSpeed;
        _accelerationSpeed = _defaultAcceleration;
        _decelerationSpeed = _defaultDecelerationSpeed;

        _creatrureAction = CreatureAction.idle;
        _isGrounded = false;
    }

// Это я сделал для тестов, по хорошему это кусок кода персонажа
// Так как это будет полезно, я это тут оставляю

/*
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
*/
    private void moveRight() 
    {
        _movementDirection = Vector3.right;
        transform.position += (_movementDirection*_movementSpeed*Time.fixedDeltaTime);
    }

    private void moveLeft() 
    {
        _movementDirection = Vector3.left;
        transform.position += (_movementDirection*_movementSpeed*Time.fixedDeltaTime);
    }

    private void postMoovement()
    {
        transform.position += (_movementDirection*_movementSpeed*Time.fixedDeltaTime);
    }

    private void recalculateSpeed(bool isMooving)
    {
        if (isMooving)
        {
            if (_movementSpeed < _maxMovementSpeed)
            {
                _movementSpeed += _accelerationSpeed;
            }
            else if (_movementSpeed > _maxMovementSpeed)
            {
                _movementSpeed = _maxMovementSpeed;
            }
        }
        else
        {
            if (_movementSpeed > _minMovementSpeed)
            {
                _movementSpeed -= _decelerationSpeed;
            }
            else if (_movementSpeed < _minMovementSpeed)
            {
                _movementSpeed = _minMovementSpeed;
            }
        }
    }
}
