using UnityEngine;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour
{
	public Transform explosion;
	public float speed = 100f;
	public Animator _animator;
	public Transform tank;
	public Transform gun;
	public Rigidbody2D bullet;
	public float bulletSpeed = 3f;
	public CheckMove check;
	public float AfterDamageImmunityTime = 3f;
	public float SpeedUpTime = 5f;
	public int WatterIgnoreLayer;

	[SerializeField]
	private int HP = 2;
	private Rigidbody2D body;
	private Vector2 moveDirection;
	private Vector3 rotation;
	private bool isImmunity = false;
	private float ImmunityAnimationFrameTime = 0.2f;
	private bool isSpeedUp = false;
	private bool isWatterIgnore = false;

	void Start()
	{
		_animator.speed = 0;
		body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (!check.target) body.AddForce(moveDirection * speed);

		if (Mathf.Abs(body.velocity.x) > speed / 100f)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
		}
		if (Mathf.Abs(body.velocity.y) > speed / 100f)
		{
			body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
		}
	}

    void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			moveDirection = new Vector2(0, 1);
			rotation = new Vector3(0, 0, 0);
			_animator.speed = 1;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			moveDirection = new Vector2(0, -1);
			rotation = new Vector3(0, 0, 180);
			_animator.speed = 1;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			moveDirection = new Vector2(-1, 0);
			rotation = new Vector3(0, 0, 90);
			_animator.speed = 1;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			moveDirection = new Vector2(1, 0);
			rotation = new Vector3(0, 0, -90);
			_animator.speed = 1;
		}
		else
		{
			moveDirection = new Vector2(0, 0);
			_animator.speed = 0;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Rigidbody2D bulletInstance = Instantiate(bullet, gun.position, Quaternion.identity) as Rigidbody2D;
			bulletInstance.velocity = gun.TransformDirection(Vector2.up * bulletSpeed);
		}

		tank.localRotation = Quaternion.Euler(rotation);

	}

	public void GetDamage(int damage)
	{
		if (!isImmunity)
		{
			if (HP - damage <= 0)
			{
				GameControl.Instance.OnPlayerDead();
				float randomZ = UnityEngine.Random.Range(0, 360f);
				Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, randomZ));
				Destroy(gameObject);
			}
			HP -= damage;
			Immunity(AfterDamageImmunityTime);
		}
	}

	public bool Immunity(float time)
	{
		if (!isImmunity)
		{
			isImmunity = true;
			StartCoroutine(DelayImmunity(time));
			return true;
		}
		return false;
	}

	private IEnumerator DelayImmunity(float time)
	{
		StartCoroutine(ImmunityAnimation());
		yield return new WaitForSecondsRealtime(time);
		isImmunity = false;
	}

	private IEnumerator ImmunityAnimation()
	{
		var playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
		while (isImmunity)
		{
			yield return new WaitForSecondsRealtime(ImmunityAnimationFrameTime);
			playerSprite.enabled = !playerSprite.enabled;
		}
		playerSprite.enabled = true;
	}

	public bool HealUp(int count = 1)
	{
		HP += count;
		return true;
	}

	public bool SpeedUp(float multiplier)
	{
		if (!isSpeedUp)
		{
			StartCoroutine(ResetSpeed(speed));
			speed *= multiplier;
			return true;
		}
		return false;
	}

	private IEnumerator ResetSpeed(float defaultValue)
	{
		yield return new WaitForSecondsRealtime(SpeedUpTime);
		speed = defaultValue;
	}

    public bool WatterIgnore(float watterIgnoreTime)
    {
		if (!isWatterIgnore)
		{
			StartCoroutine(ResetWatterIgnore(watterIgnoreTime, gameObject.layer));
			gameObject.layer = WatterIgnoreLayer;
			return true;
		}
		return false;
    }

	private IEnumerator ResetWatterIgnore(float time, int defaultValue)
	{
		yield return new WaitForSecondsRealtime(time);
		gameObject.layer = defaultValue;
	}
}
