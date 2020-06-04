using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script3 : MonoBehaviour {

    public GameObject[] go;

    void Start()
    {
        for (int i = 0; i < go.Length; i++)
        {
            DontDestroyOnLoad(go[i]);
            SceneManager.LoadScene(0);
        }
        
    }


}
