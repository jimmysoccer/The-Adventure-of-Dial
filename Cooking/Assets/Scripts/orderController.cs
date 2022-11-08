using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class orderController : MonoBehaviour
{
    //set degree of meat
    private const int rawDegree = 1;
    private const int mediumDegree = 2;
    private const int wellDoneDegree = 3;

    private float levelTimer;
    private bool[] orderShown;
    static public int[] meatDegree;//set degree of meat on order

    // Start is called before the first frame update
    void Start()
    {
        levelTimer = 0.0f;
        orderShown = new bool[]{false,false,false,false};
        meatDegree = new int[]{rawDegree,wellDoneDegree,mediumDegree,mediumDegree};
        for(int i=0;i<4;i++){
            GameObject.Find("menu"+(i+1).ToString()).transform.position = new Vector2(-85f,44f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        levelTimer += Time.deltaTime;
        //start set order appear
        for(int i=0;i<4;i++){
            if(levelTimer>=(2.0f+2.0f*i)&&levelTimer<=(3.0f+2.0f*i)&&orderShown[i]==false){
                orderShown[i]=true;
                GameObject.Find("menu"+(i+1).ToString()).transform.position = new Vector2(-8.5f+2.0f*i,4.4f);
            }
        }
    }
}