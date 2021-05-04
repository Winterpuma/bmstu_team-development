using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestSuite
{
    /// <summary>
    /// Возвращет имя текущей сцены
    /// </summary>
    private string ActiveSceneName { get => SceneManager.GetActiveScene().name; }

    /// <summary>
    /// Тестирует загрузку сцены меню
    /// </summary>
    [UnityTest]
    public IEnumerator TestMenuLoaded()
    {
		SceneManager.LoadScene("Menu");
        
        yield return null;

        Assert.AreEqual("Menu", ActiveSceneName);
    }

    /// <summary>
    /// Тестирует нажатие клавиши старта игры
    /// </summary>
    [UnityTest]
    public IEnumerator TestCheckClickStartButton()
    {
		SceneManager.LoadScene("Menu");

        yield return null;
        
        TestHelper.ClickButton("NewGame");

        yield return null;

        Assert.AreEqual("FirstLevel", ActiveSceneName);
    }

    /// <summary>
    /// Тестирует присутствие главных компонентов на сцене игры
    /// </summary>
    [UnityTest]
    public IEnumerator TestPlayerIsOnFirstLevel()
    {
		SceneManager.LoadScene("FirstLevel");

        yield return null;

        Assert.That(UnityEngine.Object.FindObjectOfType<Player>(), Is.Not.Null);
        TestHelper.AssertComponents(new string[] {"MainCharacter", "End (Idle)", "Ground", "Start (Idle)"});
    }
}
