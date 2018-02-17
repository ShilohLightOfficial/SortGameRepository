using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowDetectorScript : MonoBehaviour {
	public GameObject MasterControlObj;
	public MasterControlScript masterControlScript4;
	public Text scoreLabel;
	public Animator scoreAnm;
	// Use this for initialization
	void Start () {
		MasterControlObj = GameObject.FindGameObjectWithTag ("MasterControl");
		masterControlScript4 = MasterControlObj.GetComponent<MasterControlScript> ();
		scoreAnm = scoreLabel.GetComponent<Animator> ();
		scoreAnm.Play ("Text change animation");

	}

	// Update is called once per frame
	void Update () {

	}
	public void OnCollisionEnter2D(Collision2D col)
	{
		print ("collided");
		if (col.gameObject.tag == "yellowball") {
			masterControlScript4.score = masterControlScript4.score + 1;
			masterControlScript4.scoreLabel.color = new Color (242f/255f, 199f/255f, 19f/255f);//Yellow
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "blueball" || col.gameObject.tag == "greenball" || col.gameObject.tag == "redball") {
			print ("GAME OVER");
			Destroy (col.gameObject);
		}
	}
}
