using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject thornPrefab;
    public static float enemyHealth = 100;
    public static float enemyDamage = 25;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 1f, 2f);
        
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            enemyHealth -= Player.damage;
        }
    }
    void SpawnBullet()
    {
        Instantiate(thornPrefab, transform.position + new Vector3(0f, 2f, 0f),  thornPrefab.transform.rotation);
    }
}
