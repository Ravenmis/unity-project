using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static bool playerDead;
	public static int score;
	public Transform[] enemySpawn;
	public float enemySpawnTime = 15;
	public int maxEnemy = 15;
	public Transform playerSpawn;
	public GameObject player;
	public GameObject enemy;
	public Text scoreText;
	public Text tankText;

	void Start () 
	{
		maxEnemy = maxEnemy * 5;
		playerDead = false;
		score = 0;
		Instantiate(player, playerSpawn.position, Quaternion.identity);
		StartCoroutine (WaitEnemySpawn(enemySpawnTime));
	}

	IEnumerator WaitEnemySpawn(float t)
	{
		foreach(Transform obj in enemySpawn)
		{
			maxEnemy--;
			Instantiate(enemy, obj.position, Quaternion.identity);
		}
		yield return new WaitForSeconds (t);
		if(maxEnemy > 0) StartCoroutine (WaitEnemySpawn(enemySpawnTime));
	}

	void OnGUI()
	{
		scoreText.text = score.ToString();
<<<<<<< HEAD
		{
			Debug.Log("work");
		}
		tankText.text = "Tank:\n" + maxEnemy;
	}
=======
		tankText.text = "Tank:\n" + maxEnemy;
	}

>>>>>>> ea0684c2548ec61c848b559a17402746c6430999
	void Update ()
	{
		if (playerDead)
		{
			playerDead = false;
<<<<<<< HEAD
			SceneManager.LoadScene(3);
		}
		if (score > 749 )
		{
			SceneManager.LoadScene(2);
		}
	}
=======
			SceneManager.LoadScene(2);
		}
		if (score > 600 )
		{
			SceneManager.LoadScene(3);
		}
	}

>>>>>>> ea0684c2548ec61c848b559a17402746c6430999
}
