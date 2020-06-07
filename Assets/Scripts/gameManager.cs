using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static bool isPlayerDeath;
    static bool hasWon;
    public GameObject loseScreen;
    public GameObject winScreen;
    void Start()
    {
        isPlayerDeath = false;
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDeath)
        {
            loseScreen.SetActive(true);
        }
        else if (hasWon)
        {
            winScreen.SetActive(true);
        }
    }

    public static void playerDead()
    {
        isPlayerDeath = true;
    }
    public void restart()
    {
        SceneManager.LoadScene("i");
    }
    public static void winGame()
    {
        hasWon = true;
    }
    public void win()
    {
        SceneManager.LoadScene("i");
    }
}
