
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class fireController : MonoBehaviour
{
    private const int BIG_FIRE = 3;
    private const int MIDDLE_FIRE = 2;
    private const int SMALL_FIRE = 1;
    public Sprite bigFire;
    public Sprite middleFire;
    public Sprite smallFire;
    static public int[] currentFire;
    // Start is called before the first frame update
    void Start()
    {   
        currentFire = new int[]{BIG_FIRE,BIG_FIRE,BIG_FIRE,BIG_FIRE};
    }
    // Update is called once per frame
    void Update()
    {
        int currentPanIdex = PanController.currentPan - 1;
        string fireName = "fire"+PanController.currentPan.ToString();
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(currentFire[currentPanIdex]!=BIG_FIRE){
                currentFire[currentPanIdex]++;
            }
            switch (currentFire[currentPanIdex])
            {
                case BIG_FIRE:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = bigFire;
                    break;
                case MIDDLE_FIRE:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = middleFire;
                    break;
                case SMALL_FIRE:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = smallFire;
                    break;
                default:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = bigFire;
                    break;
            }
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(currentFire[currentPanIdex]!=SMALL_FIRE){
                currentFire[currentPanIdex]--;
            }
            switch (currentFire[currentPanIdex])
            {
                case BIG_FIRE:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = bigFire;
                    break;
                case MIDDLE_FIRE:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = middleFire;
                    break;
                case SMALL_FIRE:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = smallFire;
                    break;
                default:
                    GameObject.Find(fireName).GetComponent<SpriteRenderer>().sprite = smallFire;
                    break;
            }
        }
    }
}
