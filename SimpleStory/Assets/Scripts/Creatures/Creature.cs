using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    protected enum CreatureAction { idle, mooving, stopMooving, jumping };
    [SerializeField]
    protected CreatureAction _creatrureAction;

    [SerializeField]
    protected BoxCollider2D _collider;
    protected Rigidbody2D _rigidbody;

    [SerializeField]
    protected Vector2 _movementDirection;
    [SerializeField]
    protected LayerMask _groundLayer;

    protected const float _maxMovementSpeed = 10.0f;
    protected const float _minMovementSpeed = 0.0f;
    protected const float _movementForce = 40.0f;
    protected const float _jumpForce = 7.0f;
    protected const float _linearDrag = 30.0f;
    protected const float _verticalLinearDrag = _linearDrag * 0.1f;
    protected const float _fallMultiplier = 5f;
    protected const float _gravity = 1f;
    protected const float _groundCheckRayExtraLenght = 0.05f;

    [SerializeField]
    protected bool _isGrounded;
    [SerializeField]
    protected float _groundCheckRayLenght;

    /// <summary>
    /// Функция инициализации, вызывается до чего-либо другого.
    /// </summary>
    private void Awake()
    {
        _groundCheckRayLenght = _collider.size.y / 2 * transform.localScale.y + _groundCheckRayExtraLenght;
        _movementDirection = Vector2.zero;
        _creatrureAction = CreatureAction.idle;
        _isGrounded = false;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Функция передвижения, должна вызываться в FixedUpdate(). Направление задачется пользовательским импутом.
    /// </summary>
    protected void Move() 
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
    protected void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0.0f);
        _rigidbody.AddForce(Vector2.up*_jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Функция позволяет сделать передвижение более плавным. Должна вызываться после Move().
    /// </summary>
    protected void ModifyPhysics()
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
            _rigidbody.drag = _verticalLinearDrag;

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
