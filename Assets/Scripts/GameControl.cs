using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private static GameControl _instance;
    public static GameControl Instance
    {
        get
        {
            if (!_instance)
                _instance = GameObject.FindGameObjectWithTag("GameControl")
                    .GetComponent<GameControl>();
            return _instance;
        }
    }

    //public bool playerDead;
    public static int score;
    public Transform[] enemySpawn;
    public float enemySpawnTime = 15;
    public float GameOverSceneDelay = 2f;
    public int maxEnemy = 15;
    public int ScoreToNexLevel = 749;
    public Transform playerSpawn;
    public GameObject player;
    public GameObject enemy;
    public Text scoreText;
    public Text tankText;
	public int loadNewScene;
    public void StartGame(int loadNewScene)
    {
        SceneManager.LoadScene(loadNewScene);
    }
    
    void Start()
    {
        maxEnemy = maxEnemy * 5;
        //playerDead = false;
        //score = 0;
        Instantiate(player, playerSpawn.position, Quaternion.identity);
        StartCoroutine(WaitEnemySpawn(enemySpawnTime));
    }

    IEnumerator WaitEnemySpawn(float t)
    {
        foreach (Transform obj in enemySpawn)
        {
            maxEnemy--;
            Instantiate(enemy, obj.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(t);
        if (maxEnemy > 0)
            StartCoroutine(WaitEnemySpawn(enemySpawnTime));
    }

    void OnGUI()
    {
        scoreText.text = score.ToString();
        {
            //Debug.Log("work");
        }
        tankText.text = "Tank:\n" + maxEnemy;
    }

    void Update()
    {
        //if (playerDead)
        //{
        //	playerDead = false;
        //	SceneManager.LoadScene(3);
        //}
        if (score > ScoreToNexLevel)
        {
            SceneManager.LoadScene(loadNewScene);
        }
    }

    public void OnPlayerDead()
    {
        StartCoroutine(DelayLoadGameOverScene());
    }

    private IEnumerator DelayLoadGameOverScene()
    {
        yield return new WaitForSecondsRealtime(GameOverSceneDelay);
        score = 0;
        SceneManager.LoadScene(3);
    }
}