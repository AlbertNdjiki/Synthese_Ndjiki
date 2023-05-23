using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class ItemCollector : MonoBehaviour
{
    private int Oranges = 0;

    [SerializeField] private TMP_Text CollectiblesTxt;

    [SerializeField] private AudioSource collectionSoundEffect;

    




     void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Orange"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Oranges++;
            CollectiblesTxt.text = "Collectibles: " + Oranges;
        }
       else if (collision.gameObject.CompareTag("Pomme"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            Oranges+=2;
            CollectiblesTxt.text = "Collectibles: " + Oranges;
        }
    }
}
