using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackfish : MonoBehaviour {
	public bool up;
	//public float Speedup;
	public bool down;
	//public float Speeddown ;
	public float SPEED;
	public float STOP;
	public float HighSpeed;
	public float SD;
	public float SU;


	public GameObject MainCam;

	public bool Hunt;
	// Use this for initialization
	void Start()
	{
		up = false;
		down = true;
	}

	// Update is called once per frame
	void Update()
	{
		MainCam = GameObject.Find ("Main Camera");
		if (Hunt == false) {
			if (transform.position.x >= MainCam.transform.position.x + 5f) {
				transform.localScale = new Vector3 (-1, 1, 1);
				up = false;
				down = true;
			}
			if (transform.position.x <= MainCam.transform.position.x - 5f) {
				transform.localScale = new Vector3 (1, 1, 1);
				up = true;
				down = false;
			}
			if (up == true) {
				SU += SPEED * Time.deltaTime;
				if (SU >= HighSpeed) {
					SU = HighSpeed;
				}
				transform.position += new Vector3 (SU * Time.deltaTime, 0, 0);
			}

			if (up == false) {
				SU -= STOP * Time.deltaTime;
				if (SU < 0) {
					SU = 0;
				}
				transform.position += new Vector3 (SU * Time.deltaTime, 0, 0);
			}
			///////////////////////////////////////////////////////////////////////////////


			if (down == true) {
				SD += SPEED * Time.deltaTime;
				if (SD >= HighSpeed) {
					SD = HighSpeed;
				}
				transform.position -= new Vector3 (SD * Time.deltaTime, 0, 0);
			}

			if (down == false) {
				SD -= STOP * Time.deltaTime;
				if (SD <= 0) {
					SD = 0;
				}
				transform.position -= new Vector3 (SD * Time.deltaTime, 0, 0);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.gameObject.tag == "Fish2")
		{
			Hunt = true;
			GetComponent<Animator> ().SetInteger("Run" , 1);
			StartCoroutine(Idel());
		}
	}
	IEnumerator Idel(){
		yield return new WaitForSeconds (2f);
		Hunt = false;
		GetComponent<Animator> ().SetInteger("Run" , 0);
	}
}






