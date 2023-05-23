using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLittleFlame : MonoBehaviour
{
    public GameObject flamePrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;
    public int pointage = 0;
    public float augSpawn = 2.0f;
    private bool _estChanger = false;



    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(flameWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(flamePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x *-2, Random.Range(-screenBounds.y, screenBounds.y));
        pointage++;
        Debug.Log(pointage);
        
    }
    // Update is called once per frame
   IEnumerator flameWave()
    {
        

        while (true)
        {
            
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

    private void AugmentVitesseEnnemi()
   {
       respawnTime -= augSpawn;
    }

    private void Update()
     {
       if (pointage % 5 == 0 && pointage!=0 && _estChanger == false)
       {
       AugmentVitesseEnnemi();
    _estChanger = true;

     }
      }


}
