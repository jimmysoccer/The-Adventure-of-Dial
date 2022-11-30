
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PanController : MonoBehaviour
{
    public const int PAN1 = 1;
    public const int PAN2 = 2;
    public const int PAN3 = 3;
    public const int PAN4 = 4;
    static public int currentPan = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentPan = 1;
    }
    // Update is called once per frame
    void Update()
    {
        //choose which pan to use
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 pos = transform.position;
        if(Input.GetKeyDown("d")){
            if(currentPan!=PAN4){
                currentPan++;
                pos.x = GameObject.Find("pan"+currentPan.ToString()).transform.position.x;
            }
        }else if(Input.GetKeyDown("a")){
            if(currentPan!=PAN1){
                currentPan--;
                pos.x = GameObject.Find("pan"+currentPan.ToString()).transform.position.x;
            }
        }
        transform.position = pos;
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }
}