using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenDetectorScript : MonoBehaviour {
	public GameObject MasterControlObj;
	public MasterControlScript masterControlScript;
	MasterControlScript masterControlScript2;
	public Text scoreLabel;
	public Animator scoreAnm;
	// Use this for initialization
	void Start () {
		MasterControlObj = GameObject.FindGameObjectWithTag ("MasterControl");
		masterControlScript2 = MasterControlObj.GetComponent<MasterControlScript> ();
		scoreAnm = scoreLabel.GetComponent<Animator> ();
		scoreAnm.Play ("Text change animation");

	}

	// Update is called once per frame
	void Update () {

	}
	public void OnCollisionEnter2D(Collision2D col)
	{
		print ("collided");
		if (col.gameObject.tag == "greenball") {
			masterControlScript2.score = masterControlScript2.score + 1;
			masterControlScript2.scoreLabel.color = new Color (23f/255f, 169f/255f, 156f/255f);//Green
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "blueball" || col.gameObject.tag == "redball" || col.gameObject.tag == "yellowball") {
			print ("GAME OVER");
			Destroy (col.gameObject);
		}
	}
}
