using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Триггер смерти игрока
/// </summary>
public class DeathTrigger : MonoBehaviour
{
    /// <summary>
    /// Вызывается при столкновении с колайдером.
    /// Если столкнулся Игрок, то происходит загрузка уровня с начала (игрок умирает)
    /// </summary>
    /// <param name="other">Колайдер с котором произошло столкновение</param>
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "MainCharacter")
        {
            SceneManager.LoadScene("FirstLevel");
        }
    }
}
