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
    private float[] bigFireCompleteness;
    private float[] middleFireCompleteness;
    private float[] smallFireCompleteness;
    private float[] meatCompleteness;
    //FIXME in future 菜单引用后可能会使用菜单script的static变量
    private bool[] panHasMeat;

    //record time
    private float[] levelTimer;
    private float[] leftTime; //record the time before change fire
    private float[,] timeInterval; // 4 * 3 array, 4 pans vs 3 type of fire, small -> middle -> big fire
    private bool updateTimer;

    private bool passTime;
    private int[] previousFire;

    private bool controlTimeIntervalIncrement;

    private bool test1;
    private bool test2;
    private bool test3;

    // Start is called before the first frame update
    void Start()
    {
        bigFireCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        middleFireCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        smallFireCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        meatCompleteness = new float[]{0.0f,0.0f,0.0f,0.0f};
        panHasMeat = new bool[]{false,false,false,false};
        levelTimer = new float[]{0.0f,0.0f,0.0f,0.0f};
        leftTime = new float[]{0.0f,0.0f,0.0f,0.0f};
        timeInterval = new float[,]{{0.0f,0.0f,0.0f},{0.0f,0.0f,0.0f},{0.0f,0.0f,0.0f},{0.0f,0.0f,0.0f}};
        previousFire = new int[]{3,3,3,3};
        updateTimer = true;
        passTime = true;
        test1 = true;
        test2 = true;
        test3 = true;
    }

    //TODO 火候计算完成度
    //TODO 可控制4个锅并计算

    // Update is called once per frame
    void Update()
    {
        //record time
        if(updateTimer){
            for(int i=0;i<levelTimer.Length;i++){
                levelTimer[i] += Time.deltaTime;
            }
        }

        for(int i=0;i<leftTime.Length;i++){
            //TEST ONLY
            if(levelTimer[i]>=2&&passTime){
                panHasMeat[i] = true;
                levelTimer[i] = 0.0f;
                if(i==3){
                    passTime=false;
                }
            }
            
            //check current pan and current fire
            int currentPan = PanController.currentPan;
            int[] currentFire = fireController.currentFire;

            //calculate completeness
            if(panHasMeat[i]){
                float currentTimeInterval = levelTimer[i] - leftTime[i] + timeInterval[i,currentFire[i]-1];
                switch(currentFire[i]){
                    case 3:
                        bigFireCompleteness[i] = currentTimeInterval * bigFireSpeed;
                        break;
                    case 2:
                        middleFireCompleteness[i] = currentTimeInterval * middleFireSpeed;
                        break;
                    case 1:
                        smallFireCompleteness[i] = currentTimeInterval * smallFireSpeed;
                        break;
                    default:
                        break;
                }
                meatCompleteness[i] = bigFireCompleteness[i]+middleFireCompleteness[i]+smallFireCompleteness[i];
                print("meat completeness:"+meatCompleteness[i].ToString());
            }

            //detect if fire is changed
            if(previousFire[i]!=currentFire[i]){
                //calculate accumulated each fire's interval
                timeInterval[i,previousFire[i]-1] += levelTimer[i] - leftTime[i];
                print("detected previous fire: "+previousFire[i].ToString()+"timeInterval: "+timeInterval[i,previousFire[i]-1]);
            
                leftTime[i] = levelTimer[i];
                //!!!!!!!!!NOTICE this must set [0] to [0] otherwise, the previous will be current, the same thing
                previousFire[i] = currentFire[i];
                }

            //check if meat is done, and its current status
            if(meatCompleteness[i]<50&&test1){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = rawMeat;
            }else if(meatCompleteness[i]>50&&meatCompleteness[i]<80&&test2){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = mediumMeat;
            }else if(meatCompleteness[i]>80&&meatCompleteness[i]<110&&test3){
                GameObject.Find("meat"+(i+1).ToString()).GetComponent<SpriteRenderer>().sprite = wellDoneMeat;
            }else{

            }
        }

        
    }
}
