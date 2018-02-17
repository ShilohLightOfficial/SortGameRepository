using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedDetectorScript : MonoBehaviour {
	public GameObject MasterControlObj;
	public MasterControlScript masterControlScript;
	public Text scoreLabel;
	public Animator scoreAnm;
	// Use this for initialization
	void Start () {
		MasterControlObj = GameObject.FindGameObjectWithTag ("MasterControl");
		masterControlScript = MasterControlObj.GetComponent<MasterControlScript> ();
		scoreAnm = scoreLabel.GetComponent<Animator> ();
		scoreAnm.Play ("Text change animation");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter2D(Collision2D col)
	{
		print ("collided");

		if (col.gameObject.tag == "redball") {
			masterControlScript.score = masterControlScript.score + 1;
			masterControlScript.scoreLabel.color = new Color (203f/255f, 73f/255f, 99f/255f);//Red
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "blueball" || col.gameObject.tag == "greenball" || col.gameObject.tag == "yellowball") {
			print ("GAME OVER");
			Destroy (col.gameObject);
		}
	}
}
