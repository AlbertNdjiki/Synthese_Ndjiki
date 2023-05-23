using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulltet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
       EnemyDamage enemy = hitInfo.GetComponent<EnemyDamage>();
        if (enemy != null)
        {
            enemy.TakeDamage(100);
        }
        Destroy(gameObject);
       
    }
    // Update is called once per frame

}
