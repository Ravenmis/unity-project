using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PingPong : MonoBehaviour {

	public Transform player;
	public Transform computer;
	public Transform ball;
	public int startBallSpeed = 700;
	public float playerSpeed = 20;
	public float computerSpeed = 5.5f;
	public float playerLimitY = 0f;
	public Text playerScoreText;
	public Text computerScoreText;
	public GameObject main;
	public GameObject menu;

	private int playerScore;
	private int computerScore;

	void Start () 
	{
		Reset(0);
		Time.timeScale = 1;
        Cursor.visible = false;
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			ball.GetComponent<Rigidbody2D>().WakeUp();
			Vector2 direction = new Vector2(1,Random.Range(1.5f, -1.5f));
			if(Random.Range(0,2) == 1) direction.x *= -1;
			ball.GetComponent<Rigidbody2D>().AddForce(direction * startBallSpeed);
		}
		else if(Input.GetMouseButtonDown(1))
		{
			Reset(0);
		}

		if(Input.GetAxis("Mouse Y") > 0 && player.position.y < playerLimitY)
		{
			player.Translate(Vector2.up * playerSpeed * Time.deltaTime);
		}
		else if(Input.GetAxis("Mouse Y") < 0 && player.position.y > -playerLimitY)
		{
			player.Translate(-Vector2.up * playerSpeed * Time.deltaTime);
		}

		if(ball.position.x > 0)
		{
			float Y = Mathf.Lerp(computer.position.y, ball.position.y, computerSpeed * Time.deltaTime);
			computer.position = new Vector2(computer.position.x, Y);
		}

		playerScoreText.text = playerScore.ToString();
		computerScoreText.text = computerScore.ToString();

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			bool cond = main.activeInHierarchy;
			Time.timeScale = cond ? 0f : 1;
			main.SetActive(!cond);
			menu.SetActive(cond);
			Cursor.visible = cond;

		}
		
		
	}

	public void Reset(float x)
	{
		ball.GetComponent<Rigidbody2D>().Sleep();
		computer.position = new Vector2(computer.position.x, 0);
		player.position = new Vector2(player.position.x, 0);
		ball.position = new Vector2(0, 0);
		if(x > 0) playerScore++; else if(x < 0) computerScore++;
	}
}
