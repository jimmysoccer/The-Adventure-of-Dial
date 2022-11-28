using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barlife : MonoBehaviour {
	public float Speed;
	public bool Life;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x >= 1) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Life == true) {
			transform.localScale += new Vector3 (6.0f*Time.deltaTime, 0, 0);
			Life = false;
		}
		if (GameObject.Find ("Manage").GetComponent<Manage> ().Startgame == 1) {
			Speed = 5.0f * Time.deltaTime;
			transform.localScale -= new Vector3 (Speed * Time.deltaTime, 0, 0);
			if (transform.localScale.x <= 0) {
				transform.localScale = new Vector3 (0, 1, 1);
				GameObject.Find("Manage").GetComponent<Manage>().W_or_L = false;
				GameObject.Find ("Manage").GetComponent<Manage>().End = true;
				//GameObject.Find ("Manage").GetComponent<Manage> ().Startgame = 0;

			}
		}

	}
}
