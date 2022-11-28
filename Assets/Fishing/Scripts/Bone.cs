using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour {
    public int R;
	// Use this for initialization
	void Start () {
        R = Random.Range(0, 2);
        StartCoroutine(Des());
    }
	
	// Update is called once per frame
	void Update () {
        if (R == 1) { 
        transform.eulerAngles += new Vector3(0, 0, 50 * Time.deltaTime);
        }
        if (R ==0)
        {
            transform.eulerAngles -= new Vector3(0, 0, 50 * Time.deltaTime);
        }
        transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
	}
    IEnumerator Des()
    {
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}

