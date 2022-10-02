using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт меню 
/// </summary>
public class Menu : MonoBehaviour 
{
	/// <summary>
	/// Загрузка меню игры
	/// </summary>
	public void GoToMenu()
	{
		SceneManager.LoadScene("Menu");
		UnityEngine.Debug.Log("Menu");
	}
	
	/// <summary>
	/// Загрузка карты игры
	/// </summary>
	public void GoToGame()
	{
		EnterName.roundStart = DateTime.Now;
		SceneManager.LoadScene("FirstLevel");
		UnityEngine.Debug.Log("NewGame");
	}
	
	/// <summary>
	/// Переход на сцену с выбором уровня
	/// </summary>
	public void SelectLevel()
	{
		UnityEngine.Debug.Log("SelectLevel");
	}
	
	/// <summary>
	/// Переход на сцену с информацией об авторах
	/// </summary>
	public void About()
	{
		SceneManager.LoadScene("AboutAuthors");
		UnityEngine.Debug.Log("AboutAuthors");
	}
	
	/// <summary>
	/// Завершение игры (выход из программы)
	/// </summary>
	public void QuitGame()
	{
		Application.Quit();
		UnityEngine.Debug.Log("QuitGame");
	}

	public void GoToLeaderboard() 
    {
        SceneManager.LoadScene("Finish");
    }
	
}