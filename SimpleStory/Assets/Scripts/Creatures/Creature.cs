using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    /// <summary>
    /// Действие существа
    /// </summary>
    protected enum CreatureAction 
    { 
        /// <summary>
        /// Неподвижен
        /// </summary>
        idle, 

        /// <summary>
        /// Движется
        /// </summary>
        mooving, 

        /// <summary>
        /// Перестал двигаться
        /// </summary>
        stopMooving, 

        /// <summary>
        /// Прыгает
        /// </summary>
        jumping };
    
    /// <summary>
    /// Текущее действие существа
    /// </summary>
    [SerializeField]
    protected CreatureAction _creatrureAction;

    /// <summary>
    /// Прямоугольный коллайдр существа
    /// </summary>
    [SerializeField]
    protected BoxCollider2D _collider;

    /// <summary>
    /// Твердое тело существа
    /// </summary>
    protected Rigidbody2D _rigidbody;

    /// <summary>
    /// Направление движение существа
    /// </summary>
    [SerializeField]
    protected Vector2 _movementDirection;

    /// <summary>
    /// Слой земли, с которым будет искаться коллизия для прыжков
    /// </summary>
    [SerializeField]
    protected LayerMask _groundLayer;

    /// <summary>
    /// Максимальная скорость передвижения
    /// </summary>
    protected const float _maxMovementSpeed = 10.0f;

    /// <summary>
    /// Минимальная скорость передвижения
    /// </summary>
    protected const float _minMovementSpeed = 0.0f;

    /// <summary>
    /// Сила воздействующая на существо при движении
    /// </summary>
    protected const float _movementForce = 40.0f;

    /// <summary>
    /// Сила прыжка
    /// </summary>
    protected const float _jumpForce = 7.0f;

    /// <summary>
    /// Замедление при смене движения
    /// </summary>
    protected const float _linearDrag = 30.0f;

    /// <summary>
    /// Замедление при прыжке
    /// </summary>
    protected const float _verticalLinearDrag = _linearDrag * 0.1f;

    /// <summary>
    /// коэффициент ускорения падения
    /// </summary>
    protected const float _fallMultiplier = 5f;

    /// <summary>
    /// Коэффициент гравитации
    /// </summary>
    protected const float _gravity = 1f;

    /// <summary>
    /// Небольшое удлиление луча для проверки нахождения существа на земле, чтобы выйти за рамки колайдера
    /// </summary>
    protected const float _groundCheckRayExtraLenght = 0.05f;

    [SerializeField]
    /// <summary>
    /// Флаг аходится ли существо на земле
    /// </summary>
    /// 
    protected bool _isGrounded;
    
    /// <summary>
    /// Длина луча, который пускается из центра персонажа для проверки нахождения его на земле
    /// </summary>
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
    /// Функция передвижения, должна вызываться в FixedUpdate(). Направление задается пользовательским вводом.
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
