using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
	public GameObject S;
	public GameObject M;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Manage").GetComponent<Manage> ().Sound == 0) {
			M.GetComponent<SpriteRenderer> ().enabled = false;
			S.GetComponent<SpriteRenderer> ().enabled = true;
		}
		if (GameObject.Find ("Manage").GetComponent<Manage> ().Sound == 1) {
			M.GetComponent<SpriteRenderer> ().enabled = true;
			S.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
	void OnMouseDown(){
		GameObject.Find ("Manage").GetComponent<Manage> ().Sound += 1;
	}
}
