using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    enum CreatureAction { idle, mooving, stopMooving, jumping };
    [SerializeField]
    private CreatureAction _creatrureAction;

    [SerializeField]
    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private Vector2 _movementDirection;
    [SerializeField]
    private LayerMask _groundLayer;

    private const float _maxMovementSpeed = 10.0f;
    private const float _minMovementSpeed = 0.0f;
    private const float _movementForce = 40.0f;
    private const float _jumpForce = 7.0f;
    private const float _linearDrag = 30.0f;
    private const float _fallMultiplier = 5f;
    private const float _gravity = 1f;

    [SerializeField]
    private bool _isGrounded;
    [SerializeField]
    private float _groundCheckRayLenght;

    /// <summary>
    /// Функция инициализации, вызывается до чего-либо другого.
    /// </summary>
    private void Awake()
    {
        _groundCheckRayLenght = _collider.size.y / 2 * transform.localScale.y + 0.05f;
        _movementDirection = Vector2.zero;
        _creatrureAction = CreatureAction.idle;
        _isGrounded = false;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Функция передвижения, должна вызываться в FixedUpdate(). Направление задачется пользовательским импутом.
    /// </summary>
    private void Move() 
    {
        _rigidbody.AddForce(_movementDirection * _movementForce);

        if (Mathf.Abs(_rigidbody.velocity.x) > _maxMovementSpeed)
        {
            _rigidbody.velocity = new Vector2(Mathf.Sign(_rigidbody.velocity.x) * _maxMovementSpeed, _rigidbody.velocity.y);
        }
    }

    /// <summary>
    /// Фукнция прыжка, должна вызываться в FixedUpdate().
    /// </summary>
    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0.0f);
        _rigidbody.AddForce(Vector2.up*_jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Функция позволяет сделать передвижение более плавным. Должна вызываться после Move().
    /// </summary>
    private void ModifyPhysics()
    {
        if (_isGrounded)
        {
            _rigidbody.gravityScale = _gravity;

            if(Mathf.Sign(_movementDirection.x) != Mathf.Sign(_rigidbody.velocity.x) || _movementDirection.x == 0.0f)
            {
                _rigidbody.drag = _linearDrag;
            }
            else
            {
                _rigidbody.drag = 0f;
            }
        }
        else
        {
            _rigidbody.gravityScale = _gravity;
            _rigidbody.drag = _linearDrag * 0.1f;

            if (_rigidbody.velocity.y < 0.0f)
            {
                _rigidbody.gravityScale = _gravity * _fallMultiplier;
            }
            else if (_rigidbody.velocity.y > 0.0f && _creatrureAction != CreatureAction.jumping)
            {
                _rigidbody.gravityScale = _gravity * _fallMultiplier / 2;
            }
            
        }
    }
}
