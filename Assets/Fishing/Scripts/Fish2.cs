using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish2 : MonoBehaviour {

    public bool up;
  
    public bool down;
   
    public float SU;
	public GameObject Bone;
    public GameObject Target;
    
    void Start () {
       
        up = false;
        down = true;
    }
	
	// Update is called once per frame
	void Update () {
        Target = GameObject.Find("TARGET");
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 10);
        if (transform.eulerAngles.z >=320&& transform.eulerAngles.z <= 350)
        {
          
            up = false;
          
        }
        if (transform.eulerAngles.z >= 170 && transform.eulerAngles.z <= 200)
        {
          
            up = true;
          
        }
        if (up == true)
        {
           
            transform.eulerAngles += new Vector3(0, 0, SU * Time.deltaTime);
        }

        if (up == false)
        {
          
            transform.eulerAngles += new Vector3(0, 0,-SU * Time.deltaTime);
        }
        


        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (GameObject.Find("Manage").GetComponent<Manage>().Sound == 0)
        {
            GameObject.Find("Coin").GetComponent<AudioSource>().Play();
        }
        GameObject.Find ("Manage").GetComponent<Manage> ().Score += 1;
		GameObject.Find ("barlife").GetComponent<Barlife> ().Life = true;
		GameObject.Find ("TARGET").GetComponent<Target> ().Hunt = 0;
        Destroy(gameObject);       
    }
}


