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
    
    //set image variables
    public Sprite rawMeat;
    public Sprite mediumMeat;
    public Sprite wellDoneMeat;

    private float levelTimer;
    private float tempTimer;
    private bool[] orderShown;
    static public List<int> meatDegree;//set degree of meat on order
    static public int moveOrderIndex;//set which index of order should be moved

    // Start is called before the first frame update
    void Start()
    {
        levelTimer = 0.0f;
        tempTimer = 0.0f;
        orderShown = new bool[]{false,false,false,false};
        meatDegree = new List<int>(){rawDegree,wellDoneDegree,mediumDegree,mediumDegree};
        moveOrderIndex = -1;
    }
    // Update is called once per frame
    void Update()
    {
        if(moveOrderIndex!=-1){
            float x1 = GameObject.Find("menu1").transform.position.x;
            float x2 = GameObject.Find("menu2").transform.position.x;
            float x3 = GameObject.Find("menu3").transform.position.x;
            float x4 = GameObject.Find("menu4").transform.position.x;
            
        // GameObject.Find("menu4").name = "menu404";
            if(moveOrderIndex==0){
                if(x1>=-8.5f){
                    GameObject.Find("menu1").transform.position = new Vector2(x1-0.05f,4.4f);
                }
                if(x2>=-6.5f){
                    GameObject.Find("menu2").transform.position = new Vector2(x2-0.05f,4.4f);
                }
                if(x3>=-4.5f){
                    GameObject.Find("menu3").transform.position = new Vector2(x3-0.05f,4.4f);
                }
                if(x1<=-8.5F&&x2<=-6.5f&&x3<=-4.5f){
                    GameObject.Find("menu4").transform.position = new Vector2(-2.5f,4.4f);
                }
            }
            if(moveOrderIndex==1){
                if(x2>=-6.5f){
                    GameObject.Find("menu2").transform.position = new Vector2(x2-0.05f,4.4f);
                }
                if(x3>=-4.5f){
                    GameObject.Find("menu3").transform.position = new Vector2(x3-0.05f,4.4f);
                }
                if(x1<=-8.5F&&x2<=-6.5f&&x3<=-4.5f){
                    GameObject.Find("menu4").transform.position = new Vector2(-2.5f,4.4f);
                }
            }
            if(moveOrderIndex==2){
                if(x3>=-4.5f){
                    GameObject.Find("menu3").transform.position = new Vector2(x3-0.05f,4.4f);
                }
                if(x1<=-8.5F&&x2<=-6.5f&&x3<=-4.5f){
                    GameObject.Find("menu4").transform.position = new Vector2(-2.5f,4.4f);
                }
            }
            if(moveOrderIndex==3){
                tempTimer+= Time.deltaTime;
                if(tempTimer>=2.0f&&tempTimer<=2.5f){
                    tempTimer = 0.0f;
                    GameObject.Find("menu4").transform.position = new Vector2(-2.5f,4.4f);
                }
            }
        }
        levelTimer += Time.deltaTime;
    }
}