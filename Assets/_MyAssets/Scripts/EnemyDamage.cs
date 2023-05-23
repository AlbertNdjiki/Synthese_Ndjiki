using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int health = 100;

    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0){
            Die();
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
