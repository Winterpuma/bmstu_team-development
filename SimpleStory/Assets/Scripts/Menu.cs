using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour 
{
	// Загрузка карты игры
	public void GoToGame()
	{
		UnityEngine.Debug.Log("NewGame");
	}
	
	// Переход на сцену с выбором уровня
	public void SelectLevel()
	{
		UnityEngine.Debug.Log("SelectLevel");
	}
	
	// Переход на сцену с информацией об авторах
	public void About()
	{
		UnityEngine.Debug.Log("About");
	}

	// Завершение игры (выход из программы)
	public void QuitGame()
	{
		Application.Quit();
		UnityEngine.Debug.Log("QuitGame");
	}
	
}