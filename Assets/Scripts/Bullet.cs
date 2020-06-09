using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour {

	public int damage = 1;
	public bool isEnemy;
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(!coll.isTrigger)
		{
			if(coll.transform.CompareTag("Wall"))
			{
				Destroy(gameObject);
			}
			
			if(coll.transform.CompareTag("Block"))
			{
				Destroy(coll.transform.gameObject);
				Destroy(gameObject);
			}

			if (coll.transform.CompareTag("Bonus"))
			{
				Destroy(coll.transform.gameObject);
				Destroy(gameObject);
			}

			if (!isEnemy)
			{
				if(coll.transform.CompareTag("Enemy"))
				{
					coll.transform
						.GetComponent<EnemyControl>()
						.GetDamage(damage);

					Destroy(gameObject);
				}
			}
			else
			{
				if(coll.transform.CompareTag("Player"))
				{
					coll.transform
						.GetComponent<PlayerControl>()
						.GetDamage(damage);

					Destroy(gameObject);
				}
			}
		}
	
	}
}
