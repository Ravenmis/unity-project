using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{

    private bool showPause;

    void Start()
    {



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showPause = !showPause;
        }
    }
}