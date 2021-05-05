using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

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

    /// <summary>
    /// Тестирует победу игрока
    /// </summary>
    [UnityTest]
    public IEnumerator TestWinning()
    {
		SceneManager.LoadScene("FirstLevel");

        yield return null;

        Player player = UnityEngine.Object.FindObjectOfType<Player>();
        GameObject endFlag = GameObject.Find("End (Idle)");

        player.transform.position = endFlag.transform.position;

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual("Finish", ActiveSceneName);
    }

    /// <summary>
    /// Тестирует проигрыш игрока
    /// </summary>
    [UnityTest]
    public IEnumerator TestLosing()
    {
		SceneManager.LoadScene("FirstLevel");

        yield return null;

        Player player = UnityEngine.Object.FindObjectOfType<Player>();
        var startingPosition = player.transform.position;

        player.transform.position = new Vector3(startingPosition.x - 5, startingPosition.y, startingPosition.z);

        yield return new WaitForSeconds(1);

        Player playerAfterDeath = UnityEngine.Object.FindObjectOfType<Player>();
        var positionAfterDeath = playerAfterDeath.transform.position;

        TestHelper.AssertTwoPositions(startingPosition, positionAfterDeath, "Wrong player position after death");
    }
}
