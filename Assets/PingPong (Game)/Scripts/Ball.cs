using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public PingPong pingPomg;

	void OnBecameInvisible () 
	{
		pingPomg.Reset(transform.position.x);
	}
}
