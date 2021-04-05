using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour 
{

	public void GoToGame()
	{
		SceneManager.LoadScene(0);
		UnityEngine.Debug.Log("NewGame");
	}
	
	public void SelectLevel()
	{
		// SceneManager.LoadScene(0);
		UnityEngine.Debug.Log("SelectLevel");
	}
	
	public void About()
	{
		// SceneManager.LoadScene(0);
		UnityEngine.Debug.Log("About");
	}

	public void QuitGame()
	{
		Application.Quit();
		UnityEngine.Debug.Log("QuitGame");
	}
	

	//Load
	public void LoadGame()
	{
		
	}


	//Save
	public void SaveGame()
	{
		
	}



}