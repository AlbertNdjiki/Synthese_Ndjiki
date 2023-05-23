using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireFlame : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject flamePrefab;
    private float dirX = 0f;

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
          
            firePoint.transform.Rotate(180f,0f, 0f);

        }
        
    }

    void shoot ()

    {
        Instantiate(flamePrefab, firePoint.position, firePoint.rotation);
    }
}
