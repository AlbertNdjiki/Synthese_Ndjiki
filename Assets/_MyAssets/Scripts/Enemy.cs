using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distance = 21f; //Distance that moves the object
    public bool horizontal = true; //If the movement is horizontal or vertical
    public float speed = 7f;
    public float offset = 0f; //If yo want to modify the position at the start 

    private bool isForward = true; //If the movement is out
    private Vector3 startPos;

    public void Awake()
    {
        startPos = transform.position;
        if (horizontal)
            transform.position += Vector3.right * offset;
        else
            transform.position += Vector3.forward * offset;
    }

    // Update is called once per frame
    public void Update()
    {
        if (horizontal)
        {
            if (isForward)
            {
                if (transform.position.x < startPos.x + distance)
                {
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
                else
                    isForward = false;
            }
            else
            {
                if (transform.position.x > startPos.x)
                {
                    transform.position -= Vector3.right * Time.deltaTime * speed;
                }
                else
                    isForward = true;
            }
        }
        else
        {
            if (isForward)
            {
                if (transform.position.z < startPos.z + distance)
                {
                    transform.position += Vector3.forward * Time.deltaTime * speed;
                }
                else
                    isForward = false;
            }
            else
            {
                if (transform.position.z > startPos.z)
                {
                    transform.position -= Vector3.forward * Time.deltaTime * speed;
                }
                else
                    isForward = true;
            }
        }
    }

    public void TakeDamage()
    {
        Die();
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
