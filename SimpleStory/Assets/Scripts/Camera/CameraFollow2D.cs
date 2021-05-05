using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс слежения камеры за персонажем.
/// Обязателен тэг Player на персонаже
/// </summary>
public class CameraFollow2D : MonoBehaviour
{
	/// <summary>
	/// Амортизация камеры
	/// </summary>
	public float damping = 1.5f;

	/// <summary>
	/// Смещение камеры от центра
	/// </summary>
	public Vector2 offset = new Vector2(2f, 1f);

	/// <summary>
	/// Флаг направления движения игрока
	/// </summary>
	public bool faceLeft;

	/// <summary>
	/// Расположение игрока
	/// </summary>
	private Transform player;

	/// <summary>
	/// Прошлая координата x игрока. Нужна для обновления направления движения
	/// </summary>
	private int lastX;

	/// <summary>
	/// Инициализация камеры
	/// </summary>
	void Start()
	{
		offset = new Vector2(Mathf.Abs(offset.x), offset.y);
		FindPlayer(faceLeft);
	}

	/// <summary>
	/// Поиск игрока на сцене и установка расположения камеры на сцене 
	/// </summary>
	/// <param name="playerFaceLeft">Флаг направления движения персонажа</param>
	public void FindPlayer(bool playerFaceLeft)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		lastX = Mathf.RoundToInt(player.position.x);

		if (playerFaceLeft)
		{
			transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
		}
	}

	/// <summary>
	/// Обновление камеры
	/// </summary>
	void Update()
	{
		if (player)
		{
			int currentX = Mathf.RoundToInt(player.position.x);
			if (currentX > lastX)
			{
				faceLeft = false;
			} 
			else if (currentX < lastX)
            {
				faceLeft = true;
            }

			lastX = Mathf.RoundToInt(player.position.x);

			Vector3 target;
			if (faceLeft)
			{
				target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
			}
			else
			{
				target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
			}

			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}
