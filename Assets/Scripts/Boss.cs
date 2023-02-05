using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject ThornPrefab;
    public static int EnemyHealth = 500;
    public static int enemyDamage = 25;

    void Start()
    {
        InvokeRepeating("SpawnBullet", 1f, 3f);

    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            EnemyHealth -= Player.damage;
        }
    }
    void SpawnBullet()
    {
        Instantiate(ThornPrefab, transform.position + new Vector3(0f, 2f, 0f), ThornPrefab.transform.rotation);
    }
}
