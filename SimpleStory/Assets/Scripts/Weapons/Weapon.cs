using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabBullet;

    public void Shoot(Vector2 initialPosition, Vector2 direction)
    {
        GameObject bullet = Instantiate(_prefabBullet, initialPosition, Quaternion.identity);
        Bullet scr = bullet.GetComponent<Bullet>();
        scr.MovementDirection = direction;
    }
}
