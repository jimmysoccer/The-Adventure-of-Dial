using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject Rope;
	public int Hunt;
    // Use this for initialization
    void Start () {
       
        Rope = GameObject.Find("Rope");
    }
	
	// Update is called once per frame
	void Update () {
		
			transform.localScale = new Vector3 (1f, 1f / Rope.transform.localScale.y, 1f);
		
//		if (Rope.transform.localScale.y <= 0.99f) {
//
//			transform.localScale = new Vector3 (1, Rope.transform.localScale.y*10f , 1);
//		}
		if (Rope.GetComponent<Rope> ().Fishing == true&&Hunt==0) {
			GetComponent<BoxCollider2D> ().enabled = true;
		}
		if (Rope.GetComponent<Rope> ().Fishing == false&&Hunt==1) {
			GetComponent<BoxCollider2D> ().enabled = false;
		}

    }
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Fish") {
			Hunt = 1;
		}
    }
}
