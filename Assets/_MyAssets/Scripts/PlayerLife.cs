using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
   
    public int maxhealth = 4;
    public int currenthealth;
    [SerializeField] private AudioSource deathSoundEffect;

    public HealthBar health;

   private void Start()
    {
        currenthealth = maxhealth;
        health.SetMaxHealth(maxhealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pieges"))
        {
            TakeDamage(1);
        }
    }

    

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;

        health.SetHealth(currenthealth);

        if (currenthealth <= 0)
        {
            Die();
        }

    }

    

}
