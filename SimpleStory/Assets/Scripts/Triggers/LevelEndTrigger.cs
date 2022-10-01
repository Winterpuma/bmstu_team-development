using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Триггер победы
/// </summary>
public class LevelEndTrigger : MonoBehaviour
{
    /// <summary>
    /// Вызывается при столкновении с колайдером. 
    /// Если столкнулся Игрок, то происходит загрузка сцены победы.
    /// </summary>
    /// <param name="other">Колайдер с котором произошло столкновение</param>
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "MainCharacter")
        {
            SceneManager.LoadScene("AskName");
        }
    }
}
