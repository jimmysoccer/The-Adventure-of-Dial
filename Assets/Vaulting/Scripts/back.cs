using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// public GameObject g;



public class back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // g.GetComponent<Button>().onclick.AddListener(backToMain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
		Debug.Log ("Button Clicked. TestClick.");
	}

    public void backToMain() {
        SceneManager.LoadScene(0);
    }
}
