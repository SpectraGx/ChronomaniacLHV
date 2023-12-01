using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private EnemyBullet bulletEnemyPrefab;
    [SerializeField] private Transform controllShoot;
    [SerializeField] private float timeBetweenShoots;
    private ObjectPool<EnemyBullet> EnemyBalasPool;

    private void Start()
    {
        StartCoroutine(Shoot());
        EnemyBalasPool = new ObjectPool<EnemyBullet>(() =>
        {
            EnemyBullet bala = Instantiate(bulletEnemyPrefab,controllShoot.position,controllShoot.rotation);
            bala.DesactivateBala(DesactivateBulletPool);
            return bala;
        }, bullet =>
        {
            bullet.transform.position = controllShoot.position;
            bullet.gameObject.SetActive(true);
        }, bullet =>
        {
            bullet.gameObject.SetActive(false);
        }, bullet =>
        {
            Destroy(bullet.gameObject);
        }, true, 10, 25);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShoots);
            //Instantiate(bulletEnemyPrefab,transform.position,Quaternion.identity);
            //GameObject bulletEnemy = EnemyPool.Instance.RequestBullet();
            //bulletEnemy.transform.position = transform.position;

            EnemyBalasPool.Get();
        }
    }

    private void DesactivateBulletPool(EnemyBullet bullet){
        EnemyBalasPool.Release(bullet);
    }

}
