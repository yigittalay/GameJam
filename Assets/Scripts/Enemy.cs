using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float enemyHealth = 100;
    public static float enemyDamage = 25;

    void Start()
    {
        
    }

    void Update()
    {
       if (enemyHealth <= 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            enemyHealth -= Player.damage;
        }
    }
}
