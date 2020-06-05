using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * 10, Input.GetAxis("Vertical") * 10);
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shoot, transform.position, Quaternion.identity);
        }
        
    }
}
