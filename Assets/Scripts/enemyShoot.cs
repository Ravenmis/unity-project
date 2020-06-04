using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBetweenShoots;
    public float nextShoot = -1;
    public GameObject bullet;
    void Start()
    {
        nextShoot = Random.Range(1, 3.0f);
        timeBetweenShoots = Random.Range(3, 6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShoot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShoot = Time.time + timeBetweenShoots;
        }
    }
}
