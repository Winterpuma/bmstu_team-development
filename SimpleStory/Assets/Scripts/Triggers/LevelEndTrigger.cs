using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private int _playerLayerNumber = 7;

    /// <summary>
    /// Вызывается при столкновении с колайдером. Если слой колайдера - Игрок, то
    /// переносит на сцену выигрыша
    /// </summary>
    /// <param name="other">Колайдер с котором произошло столкновение</param>
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == _playerLayerNumber)
        {
            // SceneManager.LoadScene("Menu");
        }
    }
}
