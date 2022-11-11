using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class pointController : MonoBehaviour
{
    //set point image
    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    static public int points;//set degree of meat on order
    //score1 X 8.64 Y 4.5
    //score2 X 8.04
    //score3 X 7.44

    void modifyPoint(char points,string scoreIndex){
        switch(points){
            case '1':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = one;
                break;
            case '2':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = two;
                break;
            case '3':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = three;
                break;
            case '4':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = four;
                break;
            case '5':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = five;
                break;
            case '6':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = six;
                break;
            case '7':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = seven;
                break;
            case '8':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = eight;
                break;
            case '9':
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = nine;
                break;
            default:
                GameObject.Find(scoreIndex).GetComponent<SpriteRenderer>().sprite = zero;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        GameObject.Find("score2").transform.position = new Vector2(-86.0f,86.0f);
        GameObject.Find("score3").transform.position = new Vector2(-86.0f,86.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(points<10){
            GameObject.Find("score2").transform.position = new Vector2(-86.0f,86.0f);
            GameObject.Find("score3").transform.position = new Vector2(-86.0f,86.0f);
            char digit1 = points.ToString()[0];
            modifyPoint(digit1,"score1");
        }else if(points>9&&points<100){
            char digit1 = points.ToString()[1]; //个位数
            char digit2 = points.ToString()[0]; //十位数
            GameObject.Find("score2").transform.position = new Vector2(8.04f,4.5f);
            GameObject.Find("score3").transform.position = new Vector2(-86.0f,86.0f);
            modifyPoint(digit1,"score1");
            modifyPoint(digit2,"score2");
        }else if(points>99&&points<1000){
            char digit1 = points.ToString()[2]; //个位数
            char digit2 = points.ToString()[1]; //十位数
            char digit3 = points.ToString()[0];
            GameObject.Find("score3").transform.position = new Vector2(7.44f,4.5f);
            modifyPoint(digit1,"score1");
            modifyPoint(digit2,"score2");
            modifyPoint(digit3,"score3");
        }
    }
}