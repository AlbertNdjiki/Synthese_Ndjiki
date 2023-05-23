using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
   
    public GameObject ApplePrefab;
    public float respawnTime = 6.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AppleWave());
    }

    private void spawnApple()
    {
        GameObject a = Instantiate(ApplePrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-17.0f, 33.0f), Random.Range(-0.5f, 12f));
    }
    // Update is called once per frame
    IEnumerator AppleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnApple();
        }
    }
}
