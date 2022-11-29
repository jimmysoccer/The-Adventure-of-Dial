using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {
	public bool up;
	//public float Speedup;
	public bool down;
	//public float Speeddown ;
	public float SPEED;
	public float STOP;
	public float HighSpeed;
	public float SD;
	public float SU;

	public GameObject Items;
	public GameObject Barlife;
	// Use this for initialization
	void Start () {
		up = false;
		down = true;
		Barlife.SetActive(true);
		GameObject.Find("Manage").GetComponent<Manage>().Startgame = 1;
		Destroy(Items);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x >= 0.9f)
		{

			up = false;
			down = true;
		}
		if (transform.localScale.x <= 0.8f)
		{
			
			up = true;
			down = false;
		}
		if (up == true)
		{
			SU += SPEED * Time.deltaTime;
			if (SU >= HighSpeed)
			{
				SU = HighSpeed;
			}
			transform.localScale += new Vector3(SU * Time.deltaTime, SU * Time.deltaTime, 0);
		}

		if (up == false)
		{
			SU -= STOP * Time.deltaTime;
			if (SU < 0)
			{
				SU = 0;
			}
			transform.localScale += new Vector3(SU * Time.deltaTime, SU * Time.deltaTime, 0);
		}
		///////////////////////////////////////////////////////////////////////////////


		if (down == true)
		{
			SD += SPEED * Time.deltaTime;
			if (SD >= HighSpeed)
			{
				SD = HighSpeed;
			}
			transform.localScale -= new Vector3(SD * Time.deltaTime, SD * Time.deltaTime, 0);
		}

		if (down == false)
		{
			SD -= STOP * Time.deltaTime;
			if (SD <= 0)
			{
				SD = 0;
			}
			transform.localScale -= new Vector3(SD * Time.deltaTime, SD * Time.deltaTime, 0);
		}
	}
	void OnMouseDown(){
		Barlife.SetActive (true);
		GameObject.Find ("Manage").GetComponent<Manage> ().Startgame = 1;
		Destroy (Items);
	}
}
