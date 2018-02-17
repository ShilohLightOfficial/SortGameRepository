using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	public SpringJoint2D spring;
	public Rigidbody2D rb;

	public Vector2 target;

	//Other Zones
	public Vector2 redspawnzone = new Vector2(-5,7);
	public Vector2 greenspawnzone = new Vector2(5,7);
	public Vector2 bluespawnzone = new Vector2(-5,-7);
	public Vector2 yellowspawnzone = new Vector2(5,-7);

	public int whatColor;

	public float speed;
	public int randnum;

	public GameObject[] accents;

	void Start () {
		if (this.tag == "redball"){
			whatColor = 0;
		}
		if (this.tag == "greenball"){
			whatColor = 1;
		}
		if (this.tag == "blueball"){
			whatColor = 2;
		}
		if (this.tag == "yellowball"){
			whatColor = 3;
		}




		rb = this.GetComponent<Rigidbody2D> ();

		//What direction the ball should move towards
		randnum = Random.Range(0,3);
		if (randnum == 0){target = redspawnzone;}
		if (randnum == 1){target = greenspawnzone;}
		if (randnum == 2){target = bluespawnzone;}
		if (randnum == 3){target = yellowspawnzone;}

		//At what speed?
		speed = 0.01f;

	}






	void Awake()
	{
		spring = this.gameObject.GetComponent<SpringJoint2D>(); //"spring" is the SpringJoint2D component that I added to my object

		spring.connectedAnchor = gameObject.transform.position;//i want the anchor position to start at the object's position

	}


	void OnMouseDown()
	{

		spring.enabled = true;//I'm reactivating the SpringJoint2D component each time I'm clicking on my object becouse I'm disabling it after I'm releasing the mouse click so it will fly in the direction i was moving my mouse

	}


	void OnMouseDrag()        
	{

		if (spring.enabled = true) 
		{

			Vector2 cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);//getting cursor position

			spring.connectedAnchor = cursorPosition;//the anchor get's cursor's position


		}
	}


	void OnMouseUp()        
	{

		spring.enabled = false;//disabling the spring component

	}
	void FixedUpdate(){

		//Move towards target
		if (target.x > transform.position.x) {

			Vector2 newPos = spring.connectedAnchor + new Vector2 (speed,0);
			spring.connectedAnchor = newPos;
		} else if (target.x < transform.position.x) {
			Vector2 newPos = spring.connectedAnchor + new Vector2 (-speed,0);
			spring.connectedAnchor = newPos;

		}

		if (target.y > transform.position.y) {

			Vector2 newPos = spring.connectedAnchor + new Vector2 (0,speed);
			spring.connectedAnchor = newPos;
		} else if (target.y < transform.position.y) {
			Vector2 newPos = spring.connectedAnchor + new Vector2 (0,-speed);
			spring.connectedAnchor = newPos;
		}


		//Destroy once it gets to target
		if (transform.position.x > 4 || transform.position.x < -4){
			Destroy (gameObject);

		}

		if (transform.position.y > 6 || transform.position.y < -6){
			Destroy (gameObject);

		}

		//Instaniate Accent when reaches border
		//THIS SHOULDENT BE IN UPDATE
		if (transform.position.x == 2.77 || transform.position.x == -2.77) {
			GameObject accent = (GameObject)Instantiate (accents[whatColor], new Vector2(2.77f, this.transform.position.y), transform.rotation);
			print ("spawning accent");

		}
		if (transform.position.y == 4.95 ||  transform.position.y == -4.95) {
			GameObject accent = (GameObject)Instantiate (accents[whatColor], new Vector2(2.77f, this.transform.position.y), transform.rotation);
			print ("spawning accent");

		}

	}



	/*
	╔┓┏╦━━╦┓╔┓╔━━╗
	║┗┛║┗━╣┃║┃║╯╰║
	║┏┓║┏━╣┗╣┗╣╰╯║
	╚┛┗╩━━╩━╩━╩━━╝﻿
			*/



}
