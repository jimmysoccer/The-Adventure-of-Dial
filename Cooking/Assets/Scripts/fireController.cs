using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class fireController : MonoBehaviour
{
    public Sprite newImage;

    public GameObject ant;
    private PanController pan;
    
    // Start is called before the first frame update
    void Start()
    {   
        ant = GameObject.FindGameObjectWithTag("arrow");
        pan = ant.GetComponent<PanController>();
    }

    // Update is called once per frame
    void Update()
    {
        //control pan's fire
        // print(gameObject);
        print(pan.currentPan);
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Debug.Log("up arrow");
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newImage;
            Debug.Log("down arrow");
        }
    }
}
