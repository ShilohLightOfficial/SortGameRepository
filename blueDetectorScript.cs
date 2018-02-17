using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueDetectorScript : MonoBehaviour {
	public GameObject MasterControlObj;
	public MasterControlScript masterControlScript3;
	public Text scoreLabel;
	public Animator scoreAnm;
	// Use this for initialization
	void Start () {
		MasterControlObj = GameObject.FindGameObjectWithTag ("MasterControl");
		masterControlScript3 = MasterControlObj.GetComponent<MasterControlScript> ();
		scoreAnm = scoreLabel.GetComponent<Animator> ();
		scoreAnm.Play ("Text change animation");

	}

	// Update is called once per frame
	void Update () {

	}
	public void OnCollisionEnter2D(Collision2D col)
	{
		print ("collided");
		if (col.gameObject.tag == "blueball") {
			masterControlScript3.score = masterControlScript3.score + 1;
			masterControlScript3.scoreLabel.color = new Color (53f/255f, 74f/255f, 94f/255f);//Blue
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "redball" || col.gameObject.tag == "greenball" || col.gameObject.tag == "yellowball") {
			print ("GAME OVER");
			Destroy (col.gameObject);
		}
	}
}
