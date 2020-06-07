using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int speed = 2;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    void Update()
    {
        if (transform.position.x >= 6)
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
            speed = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else if (transform.position.x <= -6)
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
            speed = -speed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        
        void OnBecameVisible()
        {
            GetComponent<enemyShoot>().enabled = true;
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Destroy(other.gameObject);
                gameManager.playerDead();
            }

        }
    }
}
