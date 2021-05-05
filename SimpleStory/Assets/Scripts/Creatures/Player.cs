using UnityEngine;

/// <summary>
/// Класс игрока
/// </summary>
public class Player : Creature
{

    /// <summary>
    /// Вызывается каждый фрейм. В этой функции идет проверка на пользовательский инпут.
    /// </summary>
    private void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRayLenght, _groundLayer);

        if (Input.GetKey(KeyCode.D))
        {
            _movementDirection = Vector3.right;
            _creatrureAction = CreatureAction.mooving;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movementDirection = Vector3.left;
            _creatrureAction = CreatureAction.mooving;
        }
        else if (_rigidbody.velocity.x != 0.0f)
        {
            _movementDirection = Vector3.zero;
            _creatrureAction = CreatureAction.stopMooving;
        }
        else
        {
            _movementDirection = Vector3.zero;
            _creatrureAction = CreatureAction.idle;
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            _creatrureAction = CreatureAction.jumping;  
        }
        else if (_creatrureAction == CreatureAction.jumping && _isGrounded)
        {
            _creatrureAction = CreatureAction.idle;
        }
    }


    /// <summary>
    /// Вызывается раз в фиксированное время. В этой функции вызываются все что связано с физикой.
    /// </summary>
    private void FixedUpdate()
    {
        ModifyPhysics();

        if (_creatrureAction == CreatureAction.jumping && _isGrounded)
        {
            Jump();
        }
        Move();
    }
}
