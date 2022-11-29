using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {


    public bool up;
    //public float Speedup;
    public bool down;
    //public float Speeddown ;
    public float SPEED;
    public float STOP;
    public float HighSpeed;
    public float SD;
    public float SU;


	public bool Fishing;


    public GameObject Pos1;
    // Use this for initialization
    void Start()
    {
        Pos1 = GameObject.Find("Pos1");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Manage").GetComponent<Manage>().End == false)
        {
            if (Fishing == true) {
			transform.localScale += new Vector3 (0,1.5f * Time.deltaTime, 0);
			if (transform.localScale.y >= 1.7f) {
				Fishing = false;
			}
		}
            if (Fishing == false && Input.GetKey(KeyCode.LeftArrow)) {
                transform.localScale -= new Vector3(0, 1.5f * Time.deltaTime, 0);
                if (transform.localScale.y <= 0.4f)
                {
                    transform.localScale = new Vector3(0.5f, 0.4f, 0.5f);
                    Fishing = true;
                }
            }
    }

        transform.position = Pos1.transform.position;

    }
}

