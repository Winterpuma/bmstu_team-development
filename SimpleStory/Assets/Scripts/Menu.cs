using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour 
{
	/// <summary>
	/// Загрузка карты игры
	/// </summary>
	public void GoToGame()
	{
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
		UnityEngine.Debug.Log("About");
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