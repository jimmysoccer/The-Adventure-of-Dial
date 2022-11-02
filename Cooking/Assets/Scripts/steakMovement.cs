using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class steakMovement : MonoBehaviour
{
    //set image variables
    public Sprite rawMeat;
    public Sprite mediumMeat;
    public Sprite wellDoneMeat;

    //set fire speed rate
    private const float bigFireSpeed = 10.0f;
    private const float middleFireSpeed = 6.6f;
    private const float smallFireSpeed = 4.5f;

    //set meat completeness
    private float[] meatCompleteness;
    //FIXME in future 菜单引用后可能会使用菜单script的static变量
    private bool[] panHasMeat;

    //record time
    private float[] levelTimer;
    private bool updateTimer;

    private bool passTime;
    private int[] previousFire;

    // Start is called before the first frame update
    void Start()
    {
        meatCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        panHasMeat = new bool[]{false,false,false,false};
        levelTimer = new float[]{0.0f,0.0f,0.0f,0.0f};
        previousFire = new int[]{3,3,3,3};
        updateTimer = true;
        passTime = true;
    }

    //TODO 火候计算完成度
    //TODO 可控制4个锅并计算
    //TEST

    // Update is called once per frame
    void Update()
    {
        //record time
        if(updateTimer){
            for(int i=0;i<levelTimer.Length;i++){
                levelTimer[i] += Time.deltaTime;
            }
        }

        //TEST ONLY
        if(levelTimer[0]>=2&&passTime){
            panHasMeat[0] = true;
            levelTimer[0] = 0.0f;
            passTime=false;
        }
        
        //check current pan and current fire
        int currentPan = PanController.currentPan;
        int[] currentFire = fireController.currentFire;

        //calculate completeness
        if(panHasMeat[0]){
            meatCompleteness[0] = levelTimer[0] * bigFireSpeed;
            print("meat completeness:"+meatCompleteness[0].ToString());
        }

        //detect if fire is changed
        if(previousFire[0]!=currentFire[0]){
            levelTimer[0] = 0.0f;
            //!!!!!!!!!NOTICE this must set [0] to [0] otherwise, the previous will be current, the same thing
            previousFire[0] = currentFire[0];
            print("detected");
        }

        //check if meat is done, and its current status
        if(meatCompleteness[0]<=50){
            GameObject.Find("steak_005").GetComponent<SpriteRenderer>().sprite = rawMeat;
        }else if(meatCompleteness[0]<=80){
            GameObject.Find("steak_005").GetComponent<SpriteRenderer>().sprite = mediumMeat;
        }else if(meatCompleteness[0]<=110){
            GameObject.Find("steak_005").GetComponent<SpriteRenderer>().sprite = wellDoneMeat;
        }else{

        }
    }
}
