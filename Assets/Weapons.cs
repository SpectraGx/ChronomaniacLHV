using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapons : ScriptableObject
{
    public Sprite currentWeaponSpr;

    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;
    // Start is called before the first frame update

    public AudioClip[] shootBullets;
    public void Shoot()
    {
        Instantiate(bulletPrefab, GameObject.Find("PointShot").transform.position, Quaternion.identity);
    }
}
