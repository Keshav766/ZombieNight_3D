using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float health = 100f;

    public void TakeDamage(float bulletDamage)
    {
        health -= bulletDamage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
