using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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
	
}