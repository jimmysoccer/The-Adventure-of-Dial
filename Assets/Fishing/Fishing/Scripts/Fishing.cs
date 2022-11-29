using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour {
	public GameObject Rope;
	// Use this for initialization
	void Start () {
		Rope = GameObject.Find("Rope");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if (GameObject.Find ("TARGET").GetComponent<Target> ().Hunt == 0) {
			if (Rope.transform.localScale.y <= 1 && GameObject.Find ("Manage").GetComponent<Manage> ().Startgame == 1) {
				Rope.GetComponent<Rope> ().Fishing = true;
			}
		}

	}
}
