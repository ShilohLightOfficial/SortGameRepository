using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallScript : MonoBehaviour {
	public GameObject[] ballToSpawn;
	public float delay;
	public Vector2 spawnPosition;
	public float centerValue;



	// Use this for initialization
	void Start () {
		
		StartCoroutine ("SpawnBall");
		centerValue = 1.5f;

	}

	IEnumerator SpawnBall()
	{
		while (true) 
		{

			spawnPosition.x = (Random.Range(-2.0f,2.0f));
			spawnPosition.y = (Random.Range(-4.0f,4.0f));
			GameObject ball = (GameObject)Instantiate (ballToSpawn[Random.Range(0,ballToSpawn.Length)], spawnPosition, transform.rotation);
			delay = Random.Range (centerValue - 1.0f, centerValue+1.0f);
			yield return new WaitForSeconds (delay);


		}

	}

	// Update is called once per frame
	void Update () {
		centerValue = centerValue - .0000001f;

	}

	//Destory any ball that touches the outer box colliders
	public void OnCollisionEnter2D(Collision2D col)
	{
		print ("collided");
		if (col.gameObject.tag == "redball" || col.gameObject.tag == "greenball" || col.gameObject.tag == "blueball" || col.gameObject.tag == "yellowball")
		{
			Destroy(col.gameObject);
		}
	}
}
