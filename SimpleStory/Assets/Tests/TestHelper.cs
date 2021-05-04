using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestHelper : MonoBehaviour
{
    /// <summary>
    /// Нажимает на кнопку с указанным именем
    /// </summary>
    /// <param name="name">Имя кнопки</param>
    public static void ClickButton(string name)
    {
        // Find button Game Object
        var go = GameObject.Find(name);
        Assert.IsNotNull(go, "Missing button " + name);

        // Set it selected for the Event System
        EventSystem.current.SetSelectedGameObject(go);

        // Invoke click
        go.GetComponent<Button>().onClick.Invoke();
    }

    /// <summary>
    /// Проверяет, что сцена загрузилась корректно
    /// </summary>
    /// <param name="sceneName">Название сцены</param>
    /// <returns></returns>
    public static IEnumerator AssertSceneLoaded(string sceneName)
    {
        var waitForScene = new WaitForSceneLoaded(sceneName );

        yield return waitForScene;

        Assert.IsFalse(waitForScene.TimedOut, "Scene " + sceneName + " was never loaded");
    }

    /// <summary>
    /// Проверяет наличие компонентов на текущей сцене
    /// </summary>
    /// <param name="components">Массив имен проверяемых компонент</param>
    public static void AssertComponents(string[] components)
    {
        foreach (var name in components) 
        {
            Assert.IsNotNull(GameObject.Find(name), "Missing component " + name);
        }
    }
}
